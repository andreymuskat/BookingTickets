using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Roles;

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

        [HttpPost("CreateOrder/{requestedCinemaId}",Name = "CreateOrder")]
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
            _cashier.EditOrderStatus(status, code);
            return Ok("GOT IT");
        }
        private int TakeIdCinemaByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CinemaId");
            string userName = nameClaim?.Value!;
            var userCinemaId = Convert.ToInt32(userName);

            return userCinemaId;
        }
        private string TakeUsernameByCashierAuth()
        {
            var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Name");
            string userName = nameClaim?.Value!;

            return userName;
        }
    }
}
