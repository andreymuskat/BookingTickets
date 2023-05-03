using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using Core.CustomException;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public ClientController(IMapper map, IClientService client, ILogger<ClientController> log)
        {
            _mapper = map;
            _clientService = client;
        }

        [HttpGet("Sessions/Cinemas/{cinemaId}/{data}", Name = "GetAllSessionsByCinema")]
        public IActionResult GetAllSessionByCinemaId([FromHeader] int cinemaId, [FromQuery] DateTime data)
        {
            logger.Info("User sent a request to get all sessions by cinema ID");

            try
            {
                var ls = _clientService.GetFilmsByCinema(cinemaId, data);
                var res = _mapper.Map<List<SessionResponseModel>>(ls);

                logger.Info($"User received an answer and all sessions by ID {cinemaId}");

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Sessions/Film/{idFilm}/{data}", Name = "GetSessionsByFilmId")]
        public IActionResult GetAllSessionByFilmId([FromHeader] int idFilm, [FromQuery] DateTime data)
        {
            try
            {
                var sb = _clientService.GetSessionsByFilm(idFilm, data);
                var res = _mapper.Map<List<SessionResponseModel>>(sb);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Session/{idSession}", Name = "GetSessionById")]
        public IActionResult GetSessionById([FromHeader] int idSession)
        {
            try
            {
                var sb = _clientService.GetSessionById(idSession);
                var res = _mapper.Map<SessionResponseModel>(sb);

                return Ok(res);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [HttpGet("Film/{filmId}", Name = "GetFilmById")]
        public IActionResult GetFilmById([FromHeader] int filmId)
        {
            try
            {
                var fb = _clientService.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModel>(fb);

                return Ok(res);
            }
            catch (FilmException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        ///nado fix
        [HttpGet("{filmId}/Cinemas", Name = "GetCinemasByFilmId")]
        public IActionResult GetCinemasByFilmId([FromHeader] int filmId)
        {
            try
            {
                var cb = _clientService.GetCinemaByFilm(filmId);
                //tyt eror vnizy
                var res = _mapper.Map<List<CinemaResponseModelForClient>>(cb);

                return Ok(res);
            }
            catch (CinemaException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            };
        }

        [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Order/new", Name = "CreateOrder")]
        public IActionResult CreateOrderByCustomer(List<CreateOrderRequestModel> models)
        {
            //_logger.Log(LogLevel.Information, "ClientService wanted to create a new order.");
            var userId = TakeIdByClientAuth();

            try
            {
                var code = _clientService.CreateOrderByCustomer(_mapper.Map<List<CreateOrderInputModel>>(models), userId);
                //_logger.Log(LogLevel.Information, "ClientService's request completed: new order written to the database.", models);

                return Ok(code);
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
            catch (SeatException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        [Authorize(Policy = "User", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("Order/Edit", Name = "Change the order")]
        public IActionResult ChangeOrderByCustomer([FromBody]string code)
        {
            try
            {
                _clientService.CancelOrderByCustomer(code);

                return Ok();
            }
            catch (OrderException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeExceptionType), ex.ErrorCode));
            }
        }

        private int TakeIdByClientAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            string userName = nameClaim?.Value!;
            var userId = Convert.ToInt32(userName);

            return userId;
        }
    }
}

