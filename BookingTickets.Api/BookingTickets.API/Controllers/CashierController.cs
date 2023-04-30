using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public CashierController(IMapper map, IСashier cashier)
        {
            _mapper = map;
            _cashier = cashier;
        }

        [HttpPost("CreateOrder/{requestedCinemaId}", Name = "CreateOrderByCashier")]
        public IActionResult CreateOrder(CreateOrderRequestModel model, int requestedCinemaId)
        {
            _logger.Log(LogLevel.Information, "Cashier wanted to create a new order.");

            var cinemaId = TakeIdCinemaByCashierAuth();
            var name = TakeUsernameByCashierAuth();

            try
            {
                _cashier.CreateOrderByCashier(_mapper.Map<CreateOrderInputModel>(model), requestedCinemaId, cinemaId, name);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }
            _logger.Log(LogLevel.Information, "Cashier's request completed: new order written to the database.", model);
            return Ok("GOT IT");
        }

        [HttpPost("EditOrderStatus/{code}", Name = "EditOrderStatus")]
        public IActionResult EditOrderStatus(OrderStatus status, string code)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to edit order status");
            var cinemaId = TakeIdCinemaByCashierAuth();
            _cashier.EditOrderStatus(status, code, cinemaId);
            _logger.Log(LogLevel.Information, "Cashier's request completed: new order status written to the database", status, code);
            return Ok("GOT IT");
        }

        [HttpGet("GetSession/{idSession}", Name = "GetSession")]
        public IActionResult GetSessionById(int idSession)
        {
            //_logger.Log(LogLevel.Information, "Cashier sent a request to get session by id");
            try
            {
                var session = _cashier.GetSessionById(idSession);
                var res = _mapper.Map<SessionRequestModel>(session);
                //_logger.Log(LogLevel.Information, "Cashier's request find session by id was completed", idSession);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetOrder/{code}", Name = "GetOrderInBoxOffice")]
        public IActionResult FindOrderByCodeNumber(string code)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to get order by code");
            try
            {
                var orders= _cashier.FindOrderByCodeNumber(code);
                var res = _mapper.Map<SessionRequestModel>(orders);
                _logger.Log(LogLevel.Information, "Cashier's request get order by code was completed", code);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetFilm/{filmId}", Name = "GetFilmByIdByCashier")]
        public IActionResult GetFilmById(int filmId)
        {
            //_logger.Log(LogLevel.Information, "Cashier sent a request to get film by film id");
            try
            {
                var fb = _cashier.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);
                //_logger.Log(LogLevel.Information, "Cashier's request get film by id was completed", filmId);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetSession/{cinemaId}", Name = "GetSessionInHisCinema")]
        public IActionResult GetSessionsInHisCinema()
        {
            //_logger.Log(LogLevel.Information, "Cashier sent a request to get session in his cinema");
            try
            {
                int cinemaId = TakeIdCinemaByCashierAuth();
                var allSessions  = _cashier.GetSessionsInHisCinema(cinemaId);
                var res = _mapper.Map<List<SessionResponseModel>>(allSessions);
                //_logger.Log(LogLevel.Information, "Cashier's request get sessions in his cinema was completed", cinemaId);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetFreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema(int sessionId)
        {
            try
            {
                int cashiersCinemaId = TakeIdCinemaByCashierAuth();
                var freeSeats = _cashier.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatRequestModel>>(freeSeats);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        private int TakeIdCinemaByCashierAuth()
        {
            {
                var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
                string userName = nameClaim?.Value!;
                var userCinemaId = Convert.ToInt32(userName);
                return userCinemaId;
            }
        }
        private string TakeUsernameByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Name");
            string userName = nameClaim?.Value!;

            return userName;
        }
    }
}
