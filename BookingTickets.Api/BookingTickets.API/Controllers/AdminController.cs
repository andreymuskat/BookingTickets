using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
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
        private readonly FilmManager _filmManager;

        public AdminController(IMapper map, IAdmin admin)
        {
            _mapper = map;
            _admin = admin;
            _filmManager = new FilmManager();
        }

        [HttpPost("Create_New_Session")]
        public IActionResult CreateNewSession(CreateSessionRequestModel session)
        {
            _admin.CreateSession(_mapper.Map<CreateSessionInputModel>(session));

            return Ok("GOT IT");
        }

        [HttpDelete("Delete_Session")]
        public IActionResult DeleteSession(int sessionId)
        {
            _admin.DeleteSession(sessionId);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
