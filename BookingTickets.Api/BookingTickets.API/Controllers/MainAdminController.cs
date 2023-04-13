using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainAdminController: ControllerBase
    {
        private readonly IMainAdmin _mainAdmin;
        private readonly IMapper _mapper;
        private readonly ILogger<MainAdminController> _logger;

        public MainAdminController(IMapper map, IMainAdmin mainAdmin)
        {
            _mapper = map;
            _mainAdmin = mainAdmin;
        }

        [HttpPost("Add_Film")]
        public IActionResult AddNewFilm(FilmRequestModel model)
        {
            var res = _mapper.Map<FilmInputModel>(model);
            _mainAdmin.AddNewFilm(res);
            return Ok("GOT IT");
        }

        [HttpGet(Name = "AllFilms")]
        public IActionResult GetFilm(string name)
        {
            var res = _mainAdmin.GetFilmByName(name);

            return Ok(res);
        }
    }
}
