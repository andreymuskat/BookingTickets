using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.API.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Controllers
{
    [Authorize(Policy = "Cashier", AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(OrderRequestModel model)
        {
            var res = _mapper.Map<OrderBLL>(model);
            _cashier.CreateOrder(res);

            return Ok("GOT IT");
        }
    }
}