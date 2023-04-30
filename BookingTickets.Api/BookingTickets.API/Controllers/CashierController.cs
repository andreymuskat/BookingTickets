using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
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

        public CashierController(IMapper map, IСashier cashier, ILogger<CashierController> logger)
        {
            _mapper = map;
            _cashier = cashier;
            _logger = logger;
        }

        [HttpPost("Order", Name = "CreateOrderByCashier")]
        public IActionResult CreateOrder(CreateOrderRequestModel model)
        {
            _logger.Log(LogLevel.Information, "Cashier wanted to create a new order.");

            var cinemaId = TakeIdCinemaByCashierAuth();
            var userId = TakeIdByCashierAuth();

            try
            {
                _cashier.CreateOrderByCashier(_mapper.Map<CreateOrderInputModel>(model), cinemaId, userId);
            }

            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }

            _logger.Log(LogLevel.Information, "Cashier's request completed: new order written to the database.", model);

            return Ok("GOT IT");
        }

        [HttpPatch("Order/Status", Name = "EditOrderStatus")]
        public IActionResult EditOrderStatus(OrderStatus status, string code)
        {
            _logger.Log(LogLevel.Information, "Cashier sent a request to edit order status");

            var cinemaId = TakeIdCinemaByCashierAuth();
            _cashier.EditOrderStatus(status, code, cinemaId);

            _logger.Log(LogLevel.Information, "Cashier's request completed: new order status written to the database", status, code);
            
            return Ok("GOT IT");
        }

        [HttpGet("Session/{idSession:int}", Name = "Ses")]
        public IActionResult GetSessionById(int idSession)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();
            //_logger.Log(LogLevel.Information, "Cashier sent a request to get session by id");
            try
            {
                var session = _cashier.GetSessionById(idSession, cinemaId);
                var res = _mapper.Map<SessionResponseModelForClient>(session);
                //_logger.Log(LogLevel.Information, "Cashier's request find session by id was completed", idSession);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
                //_logger.Log(LogLevel.Information, "Cashier's request get sessions in his cinema was completed", cinemaId);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("FreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema(int sessionId)
        {
            try
            {
                int cashiersCinemaId = TakeIdCinemaByCashierAuth();
                var freeSeats = _cashier.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatResponseModel>>(freeSeats);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
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
