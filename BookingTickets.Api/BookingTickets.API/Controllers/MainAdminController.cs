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
using Core.ILogger;
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
        private readonly INLogLogger _logger;
        private readonly IMainAdminService _mainAdminService;
        private readonly IMapper _mapper;

        public MainAdminController(IMapper map, IMainAdminService mainAdmin, INLogLogger logger)
        {
            _mapper = map;
            _mainAdminService = mainAdmin;
            _logger = logger;
        }

        [HttpPost("Film/")]
        public IActionResult CreateFilm([FromHeader] CreateAndUpdateFilmRequestModel newFilm)
        {
            var userId = TakeIdUserAuth();
            _logger.Info($"UserId: {userId} sent a request to CREATE a new Film");

            try
            {
                var res = _mapper.Map<FilmBLL>(newFilm);
                _mainAdminService.CreateNewFilm(res);

                _logger.Info($"UserId: {userId} - request completed successfully");

                return Ok(newFilm);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpPut("Film/{id}/Edit")]
        public IActionResult EditFilm([FromHeader] CreateAndUpdateFilmRequestModel newFilm, [FromHeader] int filmId)
        {
            var userId = TakeIdUserAuth();
            _logger.Info($"UserId: {userId} sent a request to EDIT a film");

            var newFilmBLL = _mapper.Map<FilmBLL>(newFilm);

            try
            {
                _mainAdminService.EditFilm(newFilmBLL, filmId);

                _logger.Info($"UserId: {userId}  - request completed successfully");

                return Ok(newFilm);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [HttpDelete("Film/{id}/Delete")]
        public IActionResult DeleteFilm([FromHeader] int filmId)
        {
            var userId = TakeIdUserAuth();
            _logger.Info($"UserId: {userId} sent a request to DELETE a film");

            try
            {
                _mainAdminService.DeleteFilm(filmId);

                _logger.Info($"UserId: {userId}  - request completed successfully");
                return Ok();
            }
            catch(FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }

        }

        [HttpPost("Cinema")]
        public IActionResult CreateNewCinema([FromHeader] CreateAndUpdateCinemaRequestModel newCinema)
        {
            var userId = TakeIdUserAuth();
            _logger.Info($"UserId: {userId} sent a request to CREATE a new Cinema");

            _mainAdminService.CreateCinema(_mapper.Map<CinemaBLL>(newCinema));

            _logger.Info($"UserId: {userId} - request completed successfully");

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

        private int TakeIdUserAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            return userId;
        }
    }
}
