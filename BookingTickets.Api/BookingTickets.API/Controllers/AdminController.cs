using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels;
using BookingTickets.API.Model.ResponseModels.All_UserResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "AdminService", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMapper map, IAdminService admin, ILogger<AdminController> logger)
        {
            _mapper = map;
            _adminService = admin;
            _logger = logger;
        }

        [HttpPost("Session")]
        public IActionResult CreateNewSession(CreateSessionRequestModel session)
        {
            _logger.Log(LogLevel.Information, "AdminService sent a request to create a new session.");

            var cinemaId = TakeIdCinemaByAdminAuth();
            var userId = TakeIdUserAuth();

            try
            {
                _adminService.CreateSession(_mapper.Map<CreateSessionInputModel>(session), cinemaId, userId);

                _logger.Log(LogLevel.Information, "AdminService request completed: new session written to the database.", session);

                return Ok();
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpDelete("Session/{sessionId}/Delete")]
        public IActionResult DeleteSession(int sessionId)
        {
            _logger.Log(LogLevel.Information, "AdminService sent a request to delete a session.");

            try
            {
                _adminService.DeleteSession(sessionId);

            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }

            _logger.Log(LogLevel.Information, "Session deleted by admin request.");

            return Ok();
        }

        [HttpGet("Cashiers")]
        public ActionResult<List<UserResponseModel>> GetAllCashiers()
        {
            var res = _adminService.GetAllCashiers();

            return Ok(res);
        }

        [HttpPost("CashierService/New")]
        public ActionResult<UserResponseModel> CreateNewCashier(CreateCashierRequestModel cashierModel)
        {
            var cashierInputModel = _mapper.Map<CreateCashierInputModel>(cashierModel);
            var res = _mapper.Map<UserResponseModel>(_adminService.CreateNewCashier(cashierInputModel));

            return Ok(res);
        }

        [HttpDelete("CashierService/{id}/Delete")]
        public IActionResult DeleteCashierById(int cashierId)
        {
            _adminService.DeleteCashierById(cashierId);

            return Ok();
        }

        [HttpGet("Statistics/Films/{id}")]
        public StatisticsFilm_ResponseModels GetStatisticsByFilm([FromHeader] StatisticsFilm_ResquestModels statInfo)
        {
            var userCinemaId = TakeIdCinemaByAdminAuth();

            var allStaticBLL = _adminService.GetStatisticsByFilm(_mapper.Map<StatisticsFilm_InputModels>(statInfo), userCinemaId);
            var allStatic = _mapper.Map<StatisticsFilm_ResponseModels>(allStaticBLL);

            return allStatic;
        }

        private int TakeIdCinemaByAdminAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
            string userName = nameClaim?.Value!;
            var userCinemaId = Convert.ToInt32(userName);

            return userCinemaId;
        }

        private int TakeIdUserAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            return userId;
        }
    }
}
