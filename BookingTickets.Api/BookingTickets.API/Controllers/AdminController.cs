using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_UserBLLModels;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMapper map, IAdmin admin, ILogger<AdminController> logger)
        {
            _mapper = map;
            _admin = admin;
            _logger = logger;
        }

        [HttpPost("Create_New_Session")]
        public IActionResult CreateNewSession(CreateSessionRequestModel session)
        {
            _logger.Log(LogLevel.Information, "Admin sent a request to create a new session.");

            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            string userName = nameClaim?.Value;

            try
            {
                _admin.CreateSession(_mapper.Map<CreateSessionInputModel>(session));
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }

            _logger.Log(LogLevel.Information, "Admin request completed: new session written to the database.", session);

            return Ok("GOT IT");
        }

        [HttpDelete("Delete_Session/{sessionId}")]
        public IActionResult DeleteSession(int sessionId)
        {
            _logger.Log(LogLevel.Information, "Admin sent a request to delete a session.");

            try { _admin.DeleteSession(sessionId); }
            catch (SessionException ex) { return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode)); }

            _logger.Log(LogLevel.Information, "Session deleted by admin request.");

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("GetAllCashiers")]
        public ActionResult<List<UserResponseModel>> GetAllCashiers()
        {
            var res = _admin.GetAllCashiers();
            return Ok(res);
        }

        [HttpPost("Create_New_Cashier")]
        public ActionResult<UserResponseModel> CreateNewCashier(CreateCashierRequestModel cashierModel)
        {
            var cashierInputModel = _mapper.Map<CreateCashierInputModel>(cashierModel);
            var res = _mapper.Map<UserResponseModel>(_admin.CreateNewCashier(cashierInputModel));

            return Ok(res);
        }

        [HttpDelete("Delete_Cashier")]
        public IActionResult DeleteCashierById(int cashierId)
        {
            _admin.DeleteCashierById(cashierId);

            return Ok();
        }
    }
}
