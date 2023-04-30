using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using Core;

namespace BookingTickets.BLL
{
    public class OrderManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IAuthRepository _authRepository;

        public OrderManager()
        {
            _orderRepository = new OrderRepository();
            _sessionRepository = new SessionRepository();
            _seatRepository = new SeatRepository();
            _authRepository = new AuthRepository();
        }

        public List <OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            return _instanceMapperBll.MapCreateListOrderDtoModelToListOrderBll(_orderRepository.FindOrderByCodeNumber(codeNumber));
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.EditOrderStatus(status, code);
        }

        public void CreateOrderByCashier(CreateOrderInputModel order, int userId)
        {
            int secondPartCode = order.SessionId;
            int thirdPartCode = order.SeatsId;

            order.Code = CreateCode(secondPartCode, thirdPartCode);
            order.Date = DateTime.Now;
            order.UserId = userId;
            order.Status = OrderStatus.PurchasedByСashbox;

            _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
        }

        public void CreateOrderByCustomer(CreateOrderInputModel order, int userId)
        {
            int secondPartCode = order.SessionId;
            int thirdPartCode = order.SeatsId;

            order.Code = CreateCode(secondPartCode, thirdPartCode);
            order.Date = DateTime.Now;
            order.UserId = userId;
            order.Status = OrderStatus.Booking;

            _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
        }

        private string CreateCode (int secondPartCode, int thirdPartCode)
        {
            Random random = new Random();
            int firstPart = random.Next(1, 1000000);
            string code = String.Concat(firstPart, secondPartCode, thirdPartCode);
            return code;
        }
    }
}
  
