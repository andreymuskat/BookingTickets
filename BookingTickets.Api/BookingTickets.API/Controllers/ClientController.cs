using AutoMapper;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.InterfacesBll;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
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

        [HttpGet("GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId(int cinemaId)
        {
            return Ok(_client.GetFilmsByCinema(cinemaId));
        }

        [HttpGet("GetFilmById")]
        public IActionResult GetFilmById(int filmId)
        {
            return Ok(_client.GetFilmById(filmId));
        }

        [HttpGet("GetCinemasByFilmId")]
        public IActionResult GetCinemasByFilmId(int filmId)
        {
            var cb = _client.GetCinemaByFilm(filmId);
            var res = _mapper.Map<List<CinemaResponseModelForClient>>(cb);
            return Ok(res);
        }

        [HttpGet("GetCinemasByFilmId")]
        public IActionResult GetAllSessionByFilmId(int idFilm)
        {
            var sb = _client.GetSessionsByFilm(idFilm);
            var res = _mapper.Map<List<SessionResponseModelForClient>>(sb);
            return Ok(res);
        }
    }
}
