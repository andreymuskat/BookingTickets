using AutoMapper;
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
    }
}
