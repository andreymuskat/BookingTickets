using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_StatisticRequestModels;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.API.Model.ResponseModels.All_StatisticResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.BLL.Models.All_UserBLLModels;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    //[Authorize(Policy = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            string userName = nameClaim?.Value;

            _logger.Log(LogLevel.Information, "Admin sent a request to create a new session.");

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
            var listUserBll = _admin.GetAllCashiers();
            var res = _mapper.Map<List<UserResponseModel>>(listUserBll);
            return Ok(res);
        }

        [HttpPost("Create_New_Cashier")]
        public ActionResult<UserResponseModel> CreateNewCashier(CreateCashierRequestModel cashierModel)
        {
            var cashierInputModel = _mapper.Map<CreateCashierInputModel>(cashierModel);
            cashierInputModel.CinemaId = 1;
            var res = _mapper.Map<UserResponseModel>(_admin.CreateNewCashier(cashierInputModel));

            return Ok(res);
        }

        [HttpPost("Update_Cashier")]
        public ActionResult<UserResponseModel> UpdateCashier(UpdateCashierRequestModel cashier)
        {
            var cashierInputModel = _mapper.Map<UpdateCashierInputModel>(cashier);
            cashierInputModel.CinemaId = 1;
            var res = _mapper.Map<UserResponseModel>(_admin.UpdateCashier(cashierInputModel));

            return Ok(res);
        }

        [HttpDelete("Delete_Cashier/{cashierId}")]
        public IActionResult DeleteCashierById(int cashierId)
        {
            _admin.DeleteCashierById(cashierId);

            return Ok();
        }

        [HttpPost("Copy_Sessions_From_OneDay_By_DateCopy_To_DateWhereToCopy")]
        public IActionResult CopySessionsFromOneDayToAnotherByDateCopy(CopySessionsRequestModel model)
        {
            var CinemaId = 1;
            _admin.CopySession(model.DateCopy, model.DateWhereToCopy, CinemaId);

            return Ok();
        }

        [HttpGet("Statictic_Of_Days_By_Month_And_Year")]
        public ActionResult<List<StatisticOfDaysByMonthAndYearOutputModel>> StaticticOfDaysByMonthAndYear([FromQuery]StatisticOfDaysByMonthAndYearRequestModel requestModel)
        {
            var inputModel = _mapper.Map<StatisticOfDaysByMonthAndYearInputModel>(requestModel);
            inputModel.CinemaId = 7;
            var res = _mapper.Map<List<StatisticOfDaysByMonthAndYearResponseModel>>(_admin.StatisticOfDaysByMonthAndYear(inputModel));
            return Ok(res);
        }

    }
}
