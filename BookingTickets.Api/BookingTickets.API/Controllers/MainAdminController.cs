using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.NewFolder;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Core.Status;
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
        public IActionResult CreateFilm([FromHeader] CreateAndUpdateFilmRequestModel model)
        {
            _logger.Log(LogLevel.Information, "MainAdmin sent a request to create a film.");

            try
            {
                var res = _mapper.Map<FilmBLL>(model);
                _mainAdmin.CreateNewFilm(res);

                _logger.Log(LogLevel.Information, "MainAdmin request completed: film written to the database.", model);

                return Ok(model);
            }
            catch (FilmException ex) { return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode)); }
        }

        [HttpPut("Film/{id}/Edit")]
        public IActionResult EditFilm([FromHeader] CreateAndUpdateFilmRequestModel newFilm, [FromHeader] int filmId)
        {
            var newFilmBLL = _mapper.Map<FilmBLL>(newFilm);

            try
            {
                _mainAdmin.EditFilm(newFilmBLL, filmId);
            }
            catch (FilmException ex) { return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode)); }

            return Ok(newFilm);
        }

        [HttpDelete("Film/{id}/Delete")]
        public IActionResult DeleteFilm([FromHeader] int filmId)
        {
            _mainAdmin.DeleteFilm(filmId);

            return Ok();
        }

        [HttpPost("Cinema")]
        public IActionResult CreateNewCinema([FromHeader] CreateAndUpdateCinemaRequestModel newCinema)
        {
            _logger.Log(LogLevel.Information, "MainAdmin sent a request to create a cinema.");

            _mainAdmin.CreateCinema(_mapper.Map<CinemaBLL>(newCinema));

            _logger.Log(LogLevel.Information, "MainAdmin request completed: cinema written to the database.", newCinema);

            return Ok(newCinema);
        }

        [HttpPut("Cinema/{id}/Edit")]
        public IActionResult EditCinema([FromHeader] CreateAndUpdateCinemaRequestModel newCinema, [FromHeader] int cinemaId)
        {
            var newCinemaBLL = _mapper.Map<CinemaBLL>(newCinema);

            try
            {
                _mainAdmin.EditCinema(newCinemaBLL, cinemaId);
            }
            catch (FilmException ex) { return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode)); }

            return Ok(newCinema);
        }

        [HttpDelete("Cinema/{id}/Delete")]
        public IActionResult DeleteCinema([FromHeader] int cinemaId)
        {
            _mainAdmin.DeleteCinema(cinemaId);

            return Ok("GOT IT");
        }

        [HttpPost("Hall")]
        public IActionResult CreateHall(HallRequestModel model)
        {
            try
            {
                _mainAdmin.CreateHall(_mapper.Map<CreateAndUpdateHallInputModel>(model));
            }
            catch (HallException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }

            return Ok(model);
        }

        [HttpPut("Hall/{id}/Edit")]
        public IActionResult EditHall([FromHeader] HallRequestModel newHall, [FromHeader] int hallId)
        {
            var newHallBLL = _mapper.Map<CreateAndUpdateHallInputModel>(newHall);

            try
            {
                _mainAdmin.EditHall(newHallBLL, hallId);
            }
            catch (FilmException ex) { return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode)); }

            return Ok(newHall);
        }

        [HttpDelete("Hall/{id}/Delete")]
        public IActionResult DeleteHall([FromHeader] int hallId)
        {
            _mainAdmin.DeleteHall(hallId);

            return Ok("GOT IT");
        }

        [HttpPost("Hall/{id}/Row", Name = "Add Row with seats in hall")]
        public IActionResult AddRowToHall([FromHeader] AddSeatsRowsRequestModel model)
        {
            _mainAdmin.AddRowToHall(_mapper.Map<AddSeatsRowsInputModel>(model));

            return Ok("GOT IT");
        }

        [HttpPatch("User/{id}/ChangeStatus")]
        public IActionResult ChangeUserStatus([FromHeader] int userId, UserStatus status)
        {
            _mainAdmin.ChangeUserStatus(status, userId);

            return Ok("GOT IT");
        }

        [HttpGet("Statistics/Films/{id}")]
        public StatisticsFilm_ResponseModels GetStatisticsByFilm([FromHeader] StatisticsFilm_ResquestModels statInfo)
        {
            var allStaticBLL = _mainAdmin.GetStatisticsByFilm(_mapper.Map<StatisticsFilm_InputModels>(statInfo));

            var allStatic = _mapper.Map<StatisticsFilm_ResponseModels>(allStaticBLL);

            return allStatic;
        }
    }
}
