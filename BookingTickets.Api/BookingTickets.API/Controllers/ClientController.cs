using AutoMapper;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.InterfacesBll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

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
    }
}

