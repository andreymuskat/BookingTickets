using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMapper map, IAdmin admin)
        {
            _mapper = map;
            _admin = admin;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult<List<UserResponseModel>> GetAllCashier()
        {


            //var res = _mapper.Map<UserResponseModel>(x);

            return Ok(_admin.GetAllUsers());
        }

    }
}
