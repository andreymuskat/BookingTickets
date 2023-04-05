using BookingTickets.API.Model.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("{CinemaID}", Name = "GetAllFilmByCinema")]

        public IActionResult GetAllFilmByCinema(CinemaRequestModel cinema)
        {
            return Ok(film.GetAllFilmByCinema(cinema));
        }

        [HttpGet("{GetFilmByDay}", Name = "GetFilmByDay")]
        public IActionResult GetAllFilmByDay(DateTime dataTime)
        {
            var result = film.GetAllFilmByDay(dataTime);
            return Ok(result);
        }

        [HttpGet("{GetAllFilm}", Name = "GetAllFilm")]
        public IActionResult GetAllFilm()
        {
            var result = film.GetAllFilm;
            return Ok(result);
        }

        [HttpPost("{AddNewFilm}", Name = "AddNewFilm")]
        public IActionResult AddNewFilm(FilmRequestModel model)
        {
            film.AddNewFilm(model);
            return Ok("Success");
        }

        [HttpPost("{UpdateFilm}", Name = "UpdateFilm")]
        public IActionResult UpdateFilm(FilmRequestModel model)
        {
            film.UpdateFilm(model);
            return Ok("Success");
        }

    }
}
