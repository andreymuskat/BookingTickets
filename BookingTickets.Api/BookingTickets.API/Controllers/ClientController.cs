using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IMapper map, IClientService client, ILogger<ClientController> log)
        {
            _mapper = map;
            _clientService = client;
            _logger = log;
        }

        [HttpGet("Sessions/{cinemaId}", Name = "GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId(int cinemaId, DateTime time)
        {
            try
            {
                var ls = _clientService.GetFilmsByCinema(cinemaId, time);
                var res = _mapper.Map<List<SessionResponseModelForClient>>(ls);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Sessions/{idFilm}", Name = "GetSessionsByFilmId")]
        public IActionResult GetAllSessionByFilmId(int idFilm, DateTime time)
        {
            try
            {
                var sb = _clientService.GetSessionsByFilm(idFilm, time);
                var res = _mapper.Map<List<SessionResponseModelForClient>>(sb);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Session/{idSession}", Name = "GetSessionById")]
        public IActionResult GetSessionById(int idSession)
        {
            try
            {
                var sb = _clientService.GetSessionById(idSession);
                var res = _mapper.Map<SessionResponseModelForClient>(sb);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmById")]
        public IActionResult GetFilmById(int filmId)
        {
            try
            {
                var fb = _clientService.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Cinemas/{filmId}", Name = "GetCinemasByFilmId")]
        public IActionResult GetCinemasByFilmId(int filmId)
        {
            try
            {
                var cb = _clientService.GetCinemaByFilm(filmId);
                var res = _mapper.Map<List<CinemaResponseModelForClient>>(cb);

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
            _logger.Log(LogLevel.Information, "ClientService wanted to create a new order.");
            var userId = TakeIdByClientAuth();

            try
            {
                var code = _clientService.CreateOrderByCustomer(_mapper.Map<List<CreateOrderInputModel>>(models), userId);
                _logger.Log(LogLevel.Information, "ClientService's request completed: new order written to the database.", models);

                return Ok(code);
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
        [HttpPatch("Order/Modification", Name = "Change the order")]
        public IActionResult ChangeOrderByCustomer(string code)
        {
            try
            {
                _clientService.CancelOrderByCustomer(code);
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

