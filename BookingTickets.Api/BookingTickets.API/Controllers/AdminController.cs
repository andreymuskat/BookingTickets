using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
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

        [HttpPost("Create_New_Session")]
        public IActionResult CreateNewSession(SessionRequestModel session)
        {
            _admin.CreateSession(_mapper.Map<SessionBLL>(session));

            return Ok("GOT IT");
        }
    }
}
