using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using Core;

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

        public void CreateOrder(OrderBLL order)
        {
            Random random = new Random();
            int firstPart = random.Next(1, 1000000);
            int secondPart = order.Session.Film.Id;
            int thirdPart = order.Session.Id;
            string code = String.Concat(firstPart, secondPart, thirdPart);
            order.Code = code;
            if (order.User.UserStatus == UserStatus.Cashier)
            {
                order.Status = OrderStatus.PurchasedByСashbox;
            }
            else if (order.User.UserStatus == UserStatus.Client)
            {
                order.Status = OrderStatus.Booking;
            }
            _orderRepository.CreateOrder(_instanceMapperBll.MapOrderBLLToOrderDto(order));
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.FindOrderByCodeNumber(code).Status = status;   
        }
    }

}
  
