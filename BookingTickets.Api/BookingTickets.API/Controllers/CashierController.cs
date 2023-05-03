using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Core.ILogger;
using Core.Status;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "CashierService", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly INLogLogger _logger;
        private readonly ICashierService _cashierService;
        private readonly IMapper _mapper;

        public CashierController(IMapper map, ICashierService cashier, INLogLogger logger)
        {
            _mapper = map;
            _cashierService = cashier;
            _logger = logger;
        }

        [HttpPost("Order")]
        public ActionResult<List<OrderForCashierResponseModel>> CreateOrder(List<CreateOrderRequestModel> model)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'CreateOrderByCashier' request");

            try
            {
                var allNewOrders = _cashierService.CreateOrderByCashier(_mapper.Map<List<CreateOrderInputModel>>(model), cinemaId, userId);

                _logger.Info($"UserId: {userId} - request 'CreateOrderByCashier' completed successfully.");

                return Ok(_mapper.Map<List<OrderForCashierResponseModel>>(allNewOrders));
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
            catch (SeatException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpGet("Orders")]
        public ActionResult<List<OrderForCashierResponseModel>> FindOrderByCodeNumber([FromBody] string code)
        {
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'FindOrderByCodeNumber' request");

            try
            {
                List<OrderForCashierResponseModel> findeOrders = new List<OrderForCashierResponseModel>();
                List<OrderBLL> orders = _cashierService.FindOrdersByCodeNumber(code);

                for (int i = 0; i < orders.Count; i++)
                {
                    findeOrders.Add(_mapper.Map<OrderForCashierResponseModel>(orders[i]));
                }

                _logger.Info($"UserId: {userId} - request 'FindOrderByCodeNumber' completed successfully.");

                return Ok(findeOrders);
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpPatch("Order/StatusChange")]
        public IActionResult EditOrderStatus([FromHeader] OrderStatus status, [FromBody] string code)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'EditOrderStatusByCode' request");

            try
            {
                _cashierService.EditOrderStatus(status, code, cinemaId);

                _logger.Info($"UserId: {userId} - request 'EditOrderStatusByCode' completed successfully.");

                return Ok();
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpGet("Session/{idSession}")]
        public ActionResult<SessionResponseModel> GetSessionById([FromHeader] int idSession)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'GetSessionById' request");

            try
            {
                var session = _cashierService.GetSessionById(idSession, cinemaId);
                var result = _mapper.Map<SessionResponseModel>(session);

                _logger.Info($"UserId: {userId} - request 'GetSessionById' completed successfully.");

                return Ok(result);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
            catch (CinemaException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpGet("Sessions")]
        public ActionResult<List<SessionForCashierResponseModel>> GetSessionsInHisCinema()
        {
            int cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'GetSessionInHisCinema' request");

            try
            {
                var allSessions = _cashierService.GetSessionsInHisCinema(cinemaId);
                var res = _mapper.Map<List<SessionForCashierResponseModel>>(allSessions);

                _logger.Info($"UserId: {userId} - request 'GetSessionInHisCinema' completed successfully.");

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmByIdByCashier")]
        public IActionResult GetFilmById(int filmId)
        {
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'GetFilmByIdByCashier' request");

            try
            {
                var searchFilm = _cashierService.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModel>(searchFilm);

                _logger.Info($"UserId: {userId} - request 'GetFilmByIdByCashier' completed successfully.");

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("FreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema([FromHeader] int sessionId)
        {
            var cashiersCinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();
            _logger.Info($"UserId: {userId} - sent a 'GetFreeSeatsBySessionInHisCinema' request");

            try
            {
                var searchFreeSeats = _cashierService.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatResponseModel>>(searchFreeSeats);

                _logger.Info($"UserId: {userId} - sent a 'GetFreeSeatsBySessionInHisCinema' request");

                return Ok(res);
            }
            catch (SeatException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        private int TakeIdCinemaByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
            string userName = nameClaim?.Value!;
            var userCinemaId = Convert.ToInt32(userName);

            return userCinemaId;
        }

        private int TakeIdByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            return userId;
        }
    }
}
