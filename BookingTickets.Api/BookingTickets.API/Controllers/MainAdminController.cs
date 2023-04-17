﻿using AutoMapper;
using BookingTickets.API.Model.RequestModels.CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.FilmRequestModel;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
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
    }
}
