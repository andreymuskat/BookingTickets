using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CashierController
    {
        private readonly IСashier _cashier;
        private readonly IMapper _mapper;
        private readonly ILogger<CashierController> _logger;

        public CashierController(IMapper map, IСashier cashier)
        {
            _mapper = map;
            _cashier = cashier;
        }
    }
}
