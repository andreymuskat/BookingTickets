using BookingTickets.API.Model.RequestModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ILogger<HallController> _logger;

        private readonly HallRepository hallRepository;

        public HallController(ILogger<HallController> logger)
        {
            _logger = logger;
            hallRepository = new HallRepository();
        }

        [HttpGet]
        public IActionResult GetPing()
        {
            return Ok();
        }
    }
}
