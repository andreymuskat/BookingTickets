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

        public OrderManager()
        {
            _orderRepository = new OrderRepository();
            _sessionRepository = new SessionRepository();
            _seatRepository = new SeatRepository();
        }

        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber)
        {
            return _instanceMapperBll.MapCreateListOrderInputModelToListOrderDto(_orderRepository.FindOrderByCodeNumber(codeNumber));
        }

        public void CreateOrder(CreateOrderInputModel order)
        {
            SessionBLL sessionInNewOrder = _instanceMapperBll.MapSessionDtoToSessionBLL(_sessionRepository.GetSessionById(order.SessionId));
            SeatBLL seatInNewOrder = _instanceMapperBll.MapSeatDtoToSeatBLL(_seatRepository.GetSeatById(order.SeatsId));
            Random random = new Random();
            int firstPart = random.Next(1, 1000000);
            int secondPart = order.SessionId;
            int thirdPart = order.SeatsId;
            string code = String.Concat(firstPart, secondPart, thirdPart);
            order.Code = code;
            order.Date = DateTime.Now;
            order.Status = OrderStatus.PurchasedByСashbox;
            _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            var bookingOrders = _orderRepository.FindOrderByCodeNumber(code);
            foreach (var bookingOrder in bookingOrders)
            { 
                bookingOrder.Status = status; 
            _orderRepository.EditOrderStatus(status, code);
            }
        }
    }
}
  
