using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
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

        public MainAdminController(IMapper map, IMainAdmin mainAdmin, ILogger<MainAdminController> log)
        {
            _mapper = map;
            _mainAdmin = mainAdmin;
            _logger = log;
        }

        [HttpPost("Film/")]
        public IActionResult CreateFilm(CreateFilmRequestModel model)
        {
            _logger.Log(LogLevel.Information, "MainAdmin sent a request to create a film.");

            var res = _mapper.Map<FilmBLL>(model);
            _mainAdmin.CreateNewFilm(res);

            _logger.Log(LogLevel.Information, "MainAdmin request completed: film written to the database.", model);

            return Ok("GOT IT");
        }

        [HttpPost("Cinema")]
        public IActionResult CreateNewCinema(CreateCinemaRequestModel model)
        {
            _logger.Log(LogLevel.Information, "MainAdmin sent a request to create a cinema.");

            _mainAdmin.CreateCinema(_mapper.Map<CinemaBLL>(model));

            _logger.Log(LogLevel.Information, "MainAdmin request completed: cinema written to the database.", model);

            return Ok("GOT IT");
        }

        [HttpDelete("Cinema/{id}")]
        public IActionResult DeleteCinema(int cinemaId)
        {
            _mainAdmin.DeleteCinema(cinemaId);

            return Ok("GOT IT");
        }

        [HttpPost("Hall")]
        public IActionResult CreateHall(HallRequestModel model)
        {
            _mainAdmin.CreateHall(_mapper.Map<CreateHallInputModel>(model));

            return Ok("GOT IT");
        }

        [HttpDelete("Hall/{id}")]
        public IActionResult DeleteHall(int hallId)
        {
            _mainAdmin.DeleteHall(hallId);

            return Ok("GOT IT");
        }

        [HttpPost("Create/Hall/Row_With_Seats", Name = "Add Row with seats in hall")]
        public IActionResult AddRowToHall(AddSeatsRowsRequestModel model)
        {
            _mainAdmin.AddRowToHall(_mapper.Map<AddSeatsRowsInputModel>(model));

            return Ok("GOT IT");
        }

        [HttpPatch("User/ChangeStatus")]
        public IActionResult UserMakeAdmin(ChangeUserStatusRequesModel newUser)
        {
            _mainAdmin.ChangeUserStatus(_mapper.Map<ChangeUserStatusInputModel>(newUser));

            return Ok("GOT IT");
        }
    }
}
