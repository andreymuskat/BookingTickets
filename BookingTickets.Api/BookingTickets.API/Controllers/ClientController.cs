using System.Collections.Generic;
using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Core.ILogger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly INLogLogger _logger;
        private readonly IMapper _mapper;

        public ClientController(IMapper map, IClientService client, INLogLogger logger)
        {
            _mapper = map;
            _clientService = client;
            _logger = logger;
        }

        [HttpGet("Sessions/Cinemas/{cinemaId}/{data}", Name = "GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId([FromHeader] int cinemaId, [FromQuery] DateTime data)
        {
            _logger.Info($"User sent a request to get all sessions by cinema ID {cinemaId}");

            try
            {
                var ls = _clientService.GetFilmsByCinema(cinemaId, data);
                var res = _mapper.Map<List<SessionResponseModel>>(ls);

                _logger.Info($"User received an answer and all sessions by ID {cinemaId}");

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Sessions/Film/{idFilm}/{data}", Name = "GetSessionsByFilmId")]
        public IActionResult GetAllSessionByFilmId([FromHeader] int idFilm, [FromQuery] DateTime data)
        {
            _logger.Info($"User sent a request to get all sessions by film ID {idFilm}");

            try
            {
                var sb = _clientService.GetSessionsByFilm(idFilm, data);
                var res = _mapper.Map<List<SessionResponseModel>>(sb);

                _logger.Info($"User received an answer and all films by ID {idFilm}");

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Session/{idSession}", Name = "GetSessionById")]
        public IActionResult GetSessionById([FromHeader] int idSession)
        {
            _logger.Info($"User sent a request to get session by session ID {idSession}");

            try
            {
                var sb = _clientService.GetSessionById(idSession);
                var res = _mapper.Map<SessionResponseModel>(sb);

                _logger.Info($"User received an answer and session by ID {idSession}");

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmById")]
        public IActionResult GetFilmById([FromHeader] int filmId)
        {
            _logger.Info($"User sent a request to get film by film ID {filmId}");
            try
            {
                var fb = _clientService.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModel>(fb);

                _logger.Info($"User sent a request to get film by film ID {filmId}");

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }
        
        [HttpGet("{filmId}/Cinemas", Name = "GetCinemasByFilmId")]
        public IActionResult GetCinemasByFilmId([FromHeader] int filmId)
        {
            _logger.Info($"User sent a request to get all cinemas by film ID {filmId}");
            try
            {
                var cb = _clientService.GetCinemaByFilm(filmId);
                var res = _mapper.Map<List<CinemaResponseModelForClient>>(cb);

                _logger.Info($"User received an answer and all cinemas by ID {filmId}");

                return Ok(res);
            }
            catch (CinemaException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Order/new", Name = "CreateOrder")]
        public IActionResult CreateOrderByCustomer(List<CreateOrderRequestModel> models)
        {
            _logger.Info("ClientService wanted to create a new order.");

            var userId = TakeIdByClientAuth();

            try
            {
                var newOrders = _clientService.CreateOrderByCustomer(_mapper.Map<List<CreateOrderInputModel>>(models), userId);

                _logger.Info("ClientService's request completed: new order written to the database.");;

                return Ok(_mapper.Map <List<OrderForCashierResponseModel>>(newOrders));
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

        [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("Order/{id}/Edit", Name = "Change the order")]
        public IActionResult ChangeOrderByCustomer([FromHeader]int orderId)
        {
            _logger.Info($"User sent a request to change order status by order ID {orderId}");

            try
            {
                _clientService.CancelOrderByCustomer(orderId);

                _logger.Info($"User received an answer and change order status by ID {orderId}");

                return Ok();
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        private int TakeIdByClientAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            return userId;
        }
    }
}

