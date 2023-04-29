﻿using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.BLL.Roles;
using Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "Cashier", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly IСashier _cashier;
        private readonly IMapper _mapper;
        private readonly ILogger<CashierController> _logger;

        public CashierController(IMapper map, IСashier cashier)
        {
            _mapper = map;
            _cashier = cashier;
        }

        [HttpPost("CreateOrder/{requestedCinemaId}", Name = "CreateOrderByCashier")]
        public IActionResult CreateOrder(CreateOrderRequestModel model, int requestedCinemaId)
        {
            _logger.Log(LogLevel.Information, "Cashier wanted to create a new order.");

            var cinemaId = TakeIdCinemaByCashierAuth();
            var name = TakeUsernameByCashierAuth();

            try
            {
                _cashier.CreateOrderByCashier(_mapper.Map<CreateOrderInputModel>(model), requestedCinemaId, cinemaId, name);
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }
            _logger.Log(LogLevel.Information, "Cashier's request completed: new order written to the database.", model);
            return Ok("GOT IT");
        }

        [HttpPost("EditOrderStatus/{code}", Name = "EditOrderStatus")]
        public IActionResult EditOrderStatus(OrderStatus status, string code)
        {
            var cinemaId = TakeIdCinemaByCashierAuth();
            _cashier.EditOrderStatus(status, code, cinemaId);
            return Ok("GOT IT");
        }

        [HttpGet("GetSession/{idSession}", Name = "GetSession")]
        public IActionResult GetSessionById(int idSession)
        {
            try
            {
                var session = _cashier.GetSessionById(idSession);
                var res = _mapper.Map<SessionRequestModel>(session);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetOrder/{code}", Name = "GetOrderInBoxOffice")]
        public IActionResult FindOrderByCodeNumber(string code)
        {
            try
            {
                var orders= _cashier.FindOrderByCodeNumber(code);
                var res = _mapper.Map<SessionRequestModel>(orders);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetFilm/{filmId}", Name = "GetFilmByIdByCashier")]
        public IActionResult GetFilmById(int filmId)
        {
            try
            {
                var fb = _cashier.GetFilmById(filmId);
                var res = _mapper.Map<FilmResponseModelForClient>(fb);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetSession/{cinemaId}", Name = "GetSessionInHisCinema")]
        public IActionResult GetSessionsInHisCinema()
        {
            try
            {
                int cinemaId = TakeIdCinemaByCashierAuth();
                var allSessions  = _cashier.GetSessionsInHisCinema(cinemaId);
                var res = _mapper.Map<List<SessionResponseModel>>(allSessions);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            };
        }

        [HttpGet("GetFreeSeats/{sessionId}", Name = "GetFreeSeatsBySessionInHisCinema")]
        public IActionResult GetFreeSeatsBySessionInHisCinema()
        {
            try
            {
                int cashiersCinemaId = TakeIdCinemaByCashierAuth();
                var freeSeats = _cashier.GetFreeSeatsBySessionInHisCinema(sessionId, cashiersCinemaId);
                var res = _mapper.Map<List<SeatRequestModel>>(freeSeats);
                return Ok(res);
            catch
            {
                return BadRequest();
            };
        }

        private int TakeIdCinemaByCashierAuth()
        {
            {
                var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
                string userName = nameClaim?.Value!;
                var userCinemaId = Convert.ToInt32(userName);
                return userCinemaId;
            }
        }
        private string TakeUsernameByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Name");
            string userName = nameClaim?.Value!;

            return userName;
        }
    }
}
