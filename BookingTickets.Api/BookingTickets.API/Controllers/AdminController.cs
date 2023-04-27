using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using BookingTickets.BLL.Models.All_UserBLLModels;
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
        private readonly FilmManager _filmManager;

        public AdminController(IMapper map, IAdmin admin)
        {
            _mapper = map;
            _admin = admin;
            _filmManager = new FilmManager();
        }

        [HttpPost("Create_New_Session")]
        public IActionResult CreateNewSession(CreateSessionRequestModel session)
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            string userName = nameClaim?.Value;

            _admin.CreateSession(_mapper.Map<CreateSessionInputModel>(session));

            return Ok("GOT IT");
        }

        [HttpDelete("Delete_Session")]
        public IActionResult DeleteSession(int sessionId)
        {
            _admin.DeleteSession(sessionId);
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
