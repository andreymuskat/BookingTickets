using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models;
using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookingTickets.BLL.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> manager;
        private readonly IAuthRepository repository;
        private readonly IJwtConfigurationSettings settings;
        private readonly IMapper mapper;

        public AuthService(
            UserManager<IdentityUser> userManager,
            IAuthRepository authRepository,
            IJwtConfigurationSettings jwtConfigurationSettings,
            IMapper autoMapper)
        {
            repository = authRepository;
            manager = userManager;
            settings = jwtConfigurationSettings;
            mapper = autoMapper;
        }

        public async Task<AuthResult> RegisterUser(UserRegister userRegister)
        {
            var existingEmail = await manager.FindByEmailAsync(userRegister.Email);
            if (existingEmail != null)
            {
                return new AuthResult
                {
                    Success = false,
                    Error = new List<string> { "Email already registred" }
                };
            }

            var user = new IdentityUser
            {
                Email = userRegister.Email,
                UserName = userRegister.UserName
            };

            var isUserCreated = await manager.CreateAsync(user, userRegister.Password);

            if (!isUserCreated.Succeeded)
            {
                return new AuthResult
                {
                    Success = false,
                    Error = isUserCreated.Errors.Select(error => error.Description)
                };
            }
            var userDto = repository.GetUserByName(userRegister.UserName);
            var roles = GetRole();
            var token = GetJwtToken(user, roles, userDto);
            var userAddDto = mapper.Map<UserRegister, UserDto>(userRegister);
            var userId = repository.AddUser(userAddDto);

            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }

        public async Task<AuthResult> LoginUser(UserLogin userLogin)
        {
            var existingUser = await manager.FindByNameAsync(userLogin.UserName);

            if (existingUser == null)
            {
                return new AuthResult
                {
                    Success = false,
                    Error = new[] { "User not found" }
                };
            }

            var isCredentialsCorrect = await manager.CheckPasswordAsync(existingUser, userLogin.Password);
            if (!isCredentialsCorrect)
            {
                return new AuthResult
                {
                    Success = false,
                    Error = new[] { "invalid credentials" }
                };
            }
            var userDto = repository.GetUserByName(userLogin.UserName);
            var roles = GetRoleAuth(userDto);

            var token = GetJwtToken(existingUser, roles, userDto);

            return new AuthResult
            {
                Success = true,
                Token = token
            };
        }        

        private string GetJwtToken(IdentityUser user, IEnumerable<string> userRoles, UserDto userDto)
        {
            var key = Encoding.UTF8.GetBytes(settings.Key);

            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("CinemaId",userDto.CinemaId.ToString()!),
            };

            claims.AddRange(userRoles.Select(ur => new Claim(ur, "true")));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddMinutes(settings.TokenTimeToLiveMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var jwtTokenaHandler = new JwtSecurityTokenHandler();
            var token = jwtTokenaHandler.CreateToken(tokenDescriptor);
            return jwtTokenaHandler.WriteToken(token);
        }

        private IEnumerable<string> GetRole()
        {
            return new[] { "User" };
        }

        private IEnumerable<string> GetRoleAuth(UserDto userDto)
        {
            if (userDto.UserStatus == UserStatus.Admin)
            {
                return new[] { "Admin", "Cashier", "User"};
            }
            else if (userDto.UserStatus == UserStatus.MainAdmin)
            {
                return new[] { "MainAdmin", "Admin", "Cashier", "User"};
            }
            else if (userDto.UserStatus == UserStatus.Cashier)
            {
                return new[] { "Cashier", "User"};
            }
            else if (userDto.UserStatus == UserStatus.Client)
            {
                return new[] { "User" };
            }

            return new[] { "User" };
        }        
    }
}
