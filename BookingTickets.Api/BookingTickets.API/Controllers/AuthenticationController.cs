using System.Runtime.InteropServices;
using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.BLL.Authentication;
using BookingTickets.BLL.Authentication.AuthModels;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService service;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public AuthenticationController(
            IAuthService authService,
            IMapper autoMapper,
            ILogger nLogger)
        {
            service = authService;
            mapper = autoMapper;
            logger = nLogger;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userRegister = mapper.Map<UserRegisterRequest, UserRegister>(request);
            var authResult = await service.RegisterUser(userRegister);

            var response = mapper.Map<AuthResult, AuthResponse>(authResult);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userRegister = mapper.Map<UserLoginRequest, UserLogin>(request);
            var loginResult = await service.LoginUser(userRegister);

            var response = mapper.Map<AuthResult, AuthResponse>(loginResult);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
