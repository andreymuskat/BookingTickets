using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IMapper map, IClient client, ILogger<ClientController> log)
        {
            _mapper = map;
            _client = client;
            _logger = log;
        }

        [HttpGet("GetSession/Cinema/{cinemaId}", Name = "GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId(int cinemaId)
        {
            try
            {
                var ls = _client.GetFilmsByCinema(cinemaId);
                var res = _mapper.Map<List<SessionResponseModelForClient>>(ls);
                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            };
        }

        [HttpGet("GetSession/Film/{idFilm}", Name = "GetSessionsByFilmId")]
        public IActionResult GetAllSessionByFilmId(int idFilm)
        {
            try
            {
                var sb = _client.GetSessionsByFilm(idFilm);
                var res = _mapper.Map<List<SessionResponseModelForClient>>(sb);
                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            };
        }

        [HttpGet("GetSession/Session/{idSession}", Name = "GetSessionById")]
        public IActionResult GetSessionById(int idSession)
        {
            try
            {
                var sb = _client.GetSessionById(idSession);
                var res = _mapper.Map<SessionResponseModelForClient>(sb);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            };
        }

        [HttpGet("GetFilm/{filmId}", Name = "GetFilmById")]
        public IActionResult GetFilmById(int filmId)
        {
            try
            {
                var fb = _client.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);
                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            };
        }

        [HttpGet("GetCinemas/{filmId}", Name = "GetCinemasByFilmId")]
        public IActionResult GetCinemasByFilmId(int filmId)
        {
            try
            {
                var cb = _client.GetCinemaByFilm(filmId);
                var res = _mapper.Map<List<CinemaResponseModelForClient>>(cb);
                return Ok(res);
            }
            catch (CinemaException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            };
        }

        [HttpPost("CreateOrder", Name = "CreateOrder")]
        public IActionResult CreateOrderByCustomer(List<CreateOrderRequestModel> models)
        {
            _logger.Log(LogLevel.Information, "Client wanted to create a new order.");
            var userId = TakeIdByClientAuth();

            try
            {
                var code = _client.CreateOrderByCustomer(_mapper.Map<List<CreateOrderInputModel>>(models), userId);
                _logger.Log(LogLevel.Information, "Client's request completed: new order written to the database.", models);
                return Ok(code);
            }
            catch (OrderException ex) { return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode)); }
            catch (SeatException ex) { return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode)); }
        }

        [HttpPatch("UpdateOrder", Name = "Cancel the order")]
        public IActionResult CancelOrderByCustomer(string code)
        {
            try 
            {
                _client.CancelOrderByCustomer(code);
                return Ok("Success");
            }
            catch(OrderException ex) 
            { 
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode)); 
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

