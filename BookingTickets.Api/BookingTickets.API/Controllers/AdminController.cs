using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using Microsoft.AspNetCore.Mvc;
using Core;
using Azure;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IMapper map, IAdmin admin, ILogger<AdminController> logger)
        {
            _mapper = map;
            _admin = admin;
            _logger = logger;
        }

        [HttpPost("Create_New_Session")]
        public IActionResult CreateNewSession(CreateSessionRequestModel session)
        {
            _logger.Log(LogLevel.Information, "Admin sent a request to create a new session.");

            try
            {
                _admin.CreateSession(_mapper.Map<CreateSessionInputModel>(session));
            }
            catch (SessionException ex)
            {
                return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode));
            }

            _logger.Log(LogLevel.Information, "Admin request completed: new session written to the database.", session);

            return Ok("GOT IT");
        }

        [HttpDelete("Delete_Session/{sessionId}")]
        public IActionResult DeleteSession(int sessionId)
        {
            _logger.Log(LogLevel.Information, "Admin sent a request to delete a session.");

            try { _admin.DeleteSession(sessionId); }
            catch (SessionException ex) { return BadRequest(Enum.GetName(typeof(CodeException), ex.ErrorCode)); }

            _logger.Log(LogLevel.Information, "Session deleted by admin request.");

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
