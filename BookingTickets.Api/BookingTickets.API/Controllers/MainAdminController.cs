using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Core.Status;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "MainAdminService", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class MainAdminController : ControllerBase
    {
        private readonly IMainAdminService _mainAdminService;
        private readonly IMapper _mapper;
        private readonly ILogger<MainAdminController> _logger;

        public MainAdminController(IMapper map, IMainAdminService mainAdmin, ILogger<MainAdminController> log)
        {
            _mapper = map;
            _mainAdminService = mainAdmin;
            _logger = log;
        }

        [HttpPost("Film/")]
        public IActionResult CreateFilm([FromHeader] CreateAndUpdateFilmRequestModel model)
        {
            _logger.Log(LogLevel.Information, "MainAdminService sent a request to create a film.");

            try
            {
                var res = _mapper.Map<FilmBLL>(model);
                _mainAdminService.CreateNewFilm(res);

                _logger.Log(LogLevel.Information, "MainAdminService request completed: film written to the database.", model);

                return Ok(model);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpPut("Film/{id}/Edit")]
        public IActionResult EditFilm([FromHeader] CreateAndUpdateFilmRequestModel newFilm, [FromHeader] int filmId)
        {
            var newFilmBLL = _mapper.Map<FilmBLL>(newFilm);

            try
            {
                _mainAdminService.EditFilm(newFilmBLL, filmId);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }

            return Ok(newFilm);
        }

        [HttpDelete("Film/{id}/Delete")]
        public IActionResult DeleteFilm([FromHeader] int filmId)
        {
            _mainAdminService.DeleteFilm(filmId);

            return Ok();
        }

        [HttpPost("Cinema")]
        public IActionResult CreateNewCinema([FromHeader] CreateAndUpdateCinemaRequestModel newCinema)
        {
            _logger.Log(LogLevel.Information, "MainAdminService sent a request to create a cinema.");

            _mainAdminService.CreateCinema(_mapper.Map<CinemaBLL>(newCinema));

            _logger.Log(LogLevel.Information, "MainAdminService request completed: cinema written to the database.", newCinema);

            return Ok(newCinema);
        }

        [HttpPut("Cinema/{id}/Edit")]
        public IActionResult EditCinema([FromHeader] CreateAndUpdateCinemaRequestModel newCinema, [FromHeader] int cinemaId)
        {
            var newCinemaBLL = _mapper.Map<CinemaBLL>(newCinema);

            try
            {
                _mainAdminService.EditCinema(newCinemaBLL, cinemaId);

                return Ok(newCinema);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpDelete("Cinema/{id}/Delete")]
        public IActionResult DeleteCinema([FromHeader] int cinemaId)
        {
            _mainAdminService.DeleteCinema(cinemaId);

            return Ok();
        }

        [HttpPost("Hall")]
        public IActionResult CreateHall(HallRequestModel model)
        {
            try
            {
                _mainAdminService.CreateHall(_mapper.Map<CreateAndUpdateHallInputModel>(model));

                return Ok(model);
            }
            catch (HallException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }

        }

        [HttpPut("Hall/{id}/Edit")]
        public IActionResult EditHall([FromHeader] HallRequestModel newHall, [FromHeader] int hallId)
        {
            var newHallBLL = _mapper.Map<CreateAndUpdateHallInputModel>(newHall);

            try
            {
                _mainAdminService.EditHall(newHallBLL, hallId);
                return Ok(newHall);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpDelete("Hall/{id}/Delete")]
        public IActionResult DeleteHall([FromHeader] int hallId)
        {
            _mainAdminService.DeleteHall(hallId);

            return Ok();
        }

        [HttpPost("Hall/{id}/Row", Name = "Add Row with seats in hall")]
        public IActionResult AddRowToHall([FromHeader] AddSeatsRowsRequestModel model)
        {
            _mainAdminService.AddRowToHall(_mapper.Map<AddSeatsRowsInputModel>(model));

            return Ok();
        }

        [HttpPatch("User/{id}/ChangeStatus")]
        public IActionResult ChangeUserStatus([FromHeader] int userId, UserStatus status)
        {
            _mainAdminService.ChangeUserStatus(status, userId);

            return Ok();
        }

        [HttpGet("Statistics/Films/{id}")]
        public StatisticsFilm_ResponseModels GetStatisticsByFilm([FromHeader] StatisticsFilm_ResquestModels statInfo)
        {
            var allStaticBLL = _mainAdminService.GetStatisticsByFilm(_mapper.Map<StatisticsFilm_InputModels>(statInfo));

            var allStatic = _mapper.Map<StatisticsFilm_ResponseModels>(allStaticBLL);

            return allStatic;
        }
    }
}
