using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IMapper map, IClient client)
        {
            _mapper = map;
            _client = client;
        }
    }
}
