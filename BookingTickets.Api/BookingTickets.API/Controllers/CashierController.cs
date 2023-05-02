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
        private readonly ICashierService _cashierService;
        private readonly IMapper _mapper;
        private readonly ILogger<CashierController> _logger;

        public CashierController(IMapper map, ICashierService cashier, ILogger<CashierController> logger)
        {
            _mapper = map;
            _cashierService = cashier;
            _logger = logger;
        }

        [HttpPost("Order", Name = "CreateOrderByCashier")]
        public IActionResult CreateOrder(List<CreateOrderRequestModel> model)
        {
            _logger.Log(LogLevel.Information, "CashierService wanted to create a new order.");

            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();

            try
            {
                _cashierService.CreateOrderByCashier(_mapper.Map<List<CreateOrderInputModel>>(model), cinemaId, userId);

                _logger.Log(LogLevel.Information, "CashierService's request completed: new order written to the database.", model);

                return Ok();
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

        [HttpPatch("Order/Status", Name = "EditOrderStatus")]
        public IActionResult EditOrderStatus(OrderStatus status, string code)
        {
            _logger.Log(LogLevel.Information, "CashierService sent a request to edit order status");

            try
            {
                var cinemaId = TakeIdCinemaByCashierAuth();
                _cashierService.EditOrderStatus(status, code, cinemaId);

                _logger.Log(LogLevel.Information, "CashierService's request completed: new order status written to the database", status, code);

                return Ok();
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpGet("Session/{idSession:int}", Name = "Ses")]
        public IActionResult GetSessionById(int idSession)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();

            _logger.Log(LogLevel.Information, "CashierService sent a request to get session by id");

            try
            {
                var session = _cashierService.GetSessionById(idSession, cinemaId);
                var res = _mapper.Map<SessionResponseModelForClient>(session);

                _logger.Log(LogLevel.Information, "CashierService's request find session by id was completed", idSession);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Order/{code}", Name = "GetOrderInBoxOffice")]
        public IActionResult FindOrderByCodeNumber(string code)
        {
            _logger.Log(LogLevel.Information, "CashierService sent a request to get order by code");

            try
            {
                List<OrderBLL> orders = _cashierService.FindOrderByCodeNumber(code);
                List<OrderForCashierResponseModel> findeOrders = new List<OrderForCashierResponseModel>();

                for (int i = 0; i < orders.Count; i++)
                {
                    findeOrders.Add(_mapper.Map<OrderForCashierResponseModel>(orders[i]));
                }

                _logger.Log(LogLevel.Information, "CashierService's request get order by code was completed", code);

                return Ok(findeOrders);
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmByIdByCashier")]
        public IActionResult GetFilmById(int filmId)
        {
            _logger.Log(LogLevel.Information, "CashierService sent a request to get film by film id");

            try
            {
                var fb = _cashierService.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);

                _logger.Log(LogLevel.Information, "CashierService's request get film by id was completed", filmId);

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Session", Name = "GetSessionInHisCinema")]
        public IActionResult GetSessionsInHisCinema()
        {
            _logger.Log(LogLevel.Information, "CashierService sent a request to get session in his cinema");

            try
            {
                int cinemaId = TakeIdCinemaByCashierAuth();
                var allSessions = _cashierService.GetSessionsInHisCinema(cinemaId);
                var res = _mapper.Map<List<SessionForCashierResponseModel>>(allSessions);

                _logger.Log(LogLevel.Information, "CashierService's request get sessions in his cinema was completed", cinemaId);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("FreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema(int sessionId)
        {
            _logger.Log(LogLevel.Information, "CashierService sent a request to get free seats by session in his cinema");

            try
            {
                int cashiersCinemaId = TakeIdCinemaByCashierAuth();
                var freeSeats = _cashierService.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatResponseModel>>(freeSeats);

                _logger.Log(LogLevel.Information, "CashierService's request to get free seats by session in his cinema was complited");

                return Ok(res);
            }
            catch (SeatException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        private int TakeIdCinemaByCashierAuth()
        {
            _logger.Log(LogLevel.Information, "Request was sent to get cashier's cinema ID");

            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
            string userName = nameClaim?.Value!;
            var userCinemaId = Convert.ToInt32(userName);

            _logger.Log(LogLevel.Information, "Request complited", userCinemaId);

            return userCinemaId;
        }

        private int TakeIdByCashierAuth()
        {
            _logger.Log(LogLevel.Information, "Request was sent to get cashier's ID");

            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            _logger.Log(LogLevel.Information, "Request complited", userId);

            return userId;
        }
    }
}
