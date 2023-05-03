using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.BLL.Authentication;
using BookingTickets.BLL.Authentication.AuthModels;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;
using Core.ILogger;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly INLogLogger _logger;
        private readonly IAuthService service;
        private readonly IMapper mapper;

        public AuthenticationController(INLogLogger logger, IAuthService authService, IMapper autoMapper)
        {
            _logger = logger;
            service = authService;
            mapper = autoMapper;
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
                _logger.Info($"User: {request.UserName} - successfully registered.");

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
                _logger.Info($"User: {request.UserName} - successfully logged in.");

                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
