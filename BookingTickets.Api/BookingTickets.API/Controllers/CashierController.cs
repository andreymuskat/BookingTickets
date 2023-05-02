using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.Core.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using Core.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Status;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "Cashier", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly IСashier _cashier;
        private readonly IMapper _mapper;
        private readonly ILogger<CashierController> _logger;

        public CashierController(IMapper map, IСashier cashier, ILogger<CashierController> logger)
        {
            _mapper = map;
            _cashier = cashier;
            _logger = logger;
        }

        [HttpPost("Order", Name = "CreateOrderByCashier")]
        public IActionResult CreateOrder(List<CreateOrderRequestModel> model)
        {
            _logger.Log(LogLevel.Information, "Cashier wanted to create a new order.");

            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();

            try
            {
                _cashier.CreateOrderByCashier(_mapper.Map<List<CreateOrderInputModel>>(model), cinemaId, userId);
            }
            catch (OrderException ex){return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));}
            catch (SeatException ex) { return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));}

            _logger.Log(LogLevel.Information, "Cashier's request completed: new order written to the database.", model);

            return Ok("GOT IT");
        }

        [HttpPatch("Order/Status", Name = "EditOrderStatus")]
        public IActionResult EditOrderStatus(OrderStatus status, string code)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to edit order status");

            try
            {
                var cinemaId = TakeIdCinemaByCashierAuth();
                _cashier.EditOrderStatus(status, code, cinemaId);

                _logger.Log(LogLevel.Information, "Cashier's request completed: new order status written to the database", status, code);

                return Ok("GOT IT");
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
            }
        }

        [HttpGet("Session/{idSession:int}", Name = "Ses")]
        public IActionResult GetSessionById(int idSession)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();

            _logger.Log(LogLevel.Information, "Cashier sent a request to get session by id");

            try
            {
                var session = _cashier.GetSessionById(idSession, cinemaId);
                var res = _mapper.Map<SessionResponseModelForClient>(session);

                _logger.Log(LogLevel.Information, "Cashier's request find session by id was completed", idSession);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
            };
        }

        [HttpGet("Order/{code}", Name = "GetOrderInBoxOffice")]
        public IActionResult FindOrderByCodeNumber(string code)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to get order by code");

            try
            {
                List<OrderBLL> orders = _cashier.FindOrderByCodeNumber(code);
                List<OrderForCashierResponseModel> findeOrders = new List<OrderForCashierResponseModel>();

                for (int i = 0; i < orders.Count; i++)
                {
                    findeOrders.Add(_mapper.Map<OrderForCashierResponseModel>(orders[i]));
                }

                _logger.Log(LogLevel.Information, "Cashier's request get order by code was completed", code);

                return Ok(findeOrders);
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmByIdByCashier")]
        public IActionResult GetFilmById(int filmId)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to get film by film id");

            try
            {
                var fb = _cashier.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);

                _logger.Log(LogLevel.Information, "Cashier's request get film by id was completed", filmId);

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
            };
        }

        [HttpGet("Session", Name = "GetSessionInHisCinema")]
        public IActionResult GetSessionsInHisCinema()
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to get session in his cinema");

            try
            {
                int cinemaId = TakeIdCinemaByCashierAuth();
                var allSessions = _cashier.GetSessionsInHisCinema(cinemaId);
                var res = _mapper.Map<List<SessionForCashierResponseModel>>(allSessions);

                _logger.Log(LogLevel.Information, "Cashier's request get sessions in his cinema was completed", cinemaId);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
            };
        }

        [HttpGet("FreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema(int sessionId)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to get free seats by session in his cinema");

            try
            {
                int cashiersCinemaId = TakeIdCinemaByCashierAuth();
                var freeSeats = _cashier.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatResponseModel>>(freeSeats);

                _logger.Log(LogLevel.Information, "Cashier's request to get free seats by session in his cinema was complited");

                return Ok(res);
            }
            catch (SeatException ex)
            {
                return BadRequest(Enum.GetName(typeof(Code_Exception), ex.ErrorCode));
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
