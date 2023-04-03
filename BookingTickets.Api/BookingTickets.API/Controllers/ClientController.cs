using BookingTickets.API.Model.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly FilmApi film;
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            film = new FilmApi();
        }

        [HttpGet("{GetFilmByCinema}", Name = "GetAllFilmByCinema")]
        
        public IActionResult GetAllFilmByCinema(CinemaRequestModel cinema)
        {
            var result = film.GetAllFilmByCinema(cinema);
            return Ok(result);
        }

    }
}
