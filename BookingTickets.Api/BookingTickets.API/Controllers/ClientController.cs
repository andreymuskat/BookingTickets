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

        [HttpGet( Name = "GetAllFilmByCinema")]

        public IActionResult GetAllFilmByCinema(CinemaRequestModel cinema)
        {
            return Ok(film.GetAllFilmByCinema(cinema));
        }

        [HttpGet( Name = "GetFilmByDay")]
        public IActionResult GetAllFilmByDay(DateTime dataTime)
        {
            var result = film.GetAllFilmByDay(dataTime);
            return Ok(result);
        }

        [HttpGet( Name = "GetAllFilm")]
        public IActionResult GetAllFilm()
        {
            var result = film.GetAllFilm;
            return Ok(result);
        }

        [HttpPost( Name = "AddNewFilm")]
        public IActionResult AddNewFilm(FilmRequestModel model)
        {
            film.AddNewFilm(model);
            return Ok("Success");
        }

        [HttpPost( Name = "UpdateFilm")]
        public IActionResult UpdateFilm(FilmRequestModel model)
        {
            film.UpdateFilm(model);
            return Ok("Success");
        }

    }
}
