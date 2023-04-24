using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class OrderManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;

        public OrderManager()
        {
            _orderRepository = new OrderRepository();
        }
        
        public OrderBLL FindOrderByCodeNumber(string codeNumber)
        { 
            return _instanceMapperBll.MapOrderDtoToOrderBll(_orderRepository.FindOrderByCodeNumber(codeNumber));
        }
    }
}
