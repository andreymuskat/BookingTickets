using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainAdminController: ControllerBase
    {
        private readonly MainAdmin _mainAdmin;
        private readonly MapperAPI _mapper;
        private readonly ILogger<MainAdminController> _logger;

        public MainAdminController(
            ILogger<MainAdminController> logger,
            MapperAPI mapper,
            MainAdmin mainAdmin)
        {
            _logger = logger;
            _mainAdmin = mainAdmin;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddNewFilm(FilmRequestModel model)
        {
            _mainAdmin.AddNewFilm(_mapper.MapFilmRequestModelToFilmInputModel(model));
            return Ok("GOT IT");
        }
    }
}
