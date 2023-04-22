using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.NewFolder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "MainAdmin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class MainAdminController : ControllerBase
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
        public IActionResult AddNewFilm(CreateFilmRequestModel model)
        {
            var res = _mapper.Map<FilmBLL>(model);
            _mainAdmin.CreateNewFilm(res);

            return Ok("GOT IT");
        }

        [HttpPost("Create_New_Cinema")]
        public IActionResult CreateNewCinema(CreateCinemaRequestModel model)
        {
            _mainAdmin.CreateCinema(_mapper.Map<CinemaBLL>(model));

            return Ok("GOT IT");
        }

        [HttpPost("Create_New_Hall")]
        public IActionResult CreateHall(HallRequestModel model)
        {
            _mainAdmin.CreateHall(_mapper.Map<HallBLL>(model));

            return Ok("GOT IT");
        }

        [HttpPost("Create_Row_With_Seats_In_Hall")]
        public IActionResult AddRowToHall(AddSeatsRowsRequestModel model)
        {
            _mainAdmin.AddRowToHall(_mapper.Map<AddSeatsRowsInputModel>(model));

            return Ok("GOT IT");
        }
    }
}
