using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.BLL.Roles;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Roles;


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

        public ClientController(IMapper map, IClient client)
        {
            _mapper = map;
            _client = client;
        }

        [HttpGet("GetAllSession/{cinemaId}", Name = "GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId(int cinemaId)
        {
            try
            {
                var ls = _client.GetFilmsByCinema(cinemaId);
                var res = _mapper.Map<List<SessionResponseModelForClient>>(ls);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            };
        }
        [HttpPost("CreateOrder/{requestedCinemaId}", Name = "CreateOrder")]
        public IActionResult CreateOrder(CreateOrderRequestModel model, int requestedCinemaId)
        {
            _logger.Log(LogLevel.Information, "Client wanted to create a new order.");

 
            var name = TakeUsernameByClientAuth();

            try
            {
                _client.CreateOrderByCustomer(_mapper.Map<CreateOrderInputModel>(model), name);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }
            _logger.Log(LogLevel.Information, "Client's request completed: new order written to the database.", model);
            return Ok("GOT IT");
        }
        private string TakeUsernameByClientAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Name");
            string userName = nameClaim?.Value!;

            return userName;
        }
    }
}

