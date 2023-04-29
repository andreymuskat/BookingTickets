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

        public List <OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            return _instanceMapperBll.MapCreateListOrderDtoModelToListOrderBll(_orderRepository.FindOrderByCodeNumber(codeNumber));
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

        public void CreateOrderByCashier(CreateOrderInputModel order, int cinemaId, string name)
        {
            SessionBLL sessionInNewOrder = _instanceMapperBll.MapSessionDtoToSessionBLL(_sessionRepository.GetSessionById(order.SessionId));
            SeatBLL seatInNewOrder = _instanceMapperBll.MapSeatDtoToSeatBLL(_seatRepository.GetSeatById(order.SeatsId));
            int secondPartCode = order.SessionId;
            int thirdPartCode = order.SeatsId;
            order.Code = CreateCode(secondPartCode, thirdPartCode);
            order.Date = DateTime.Now;
            order.User.UserName = name;
            order.Status = OrderStatus.PurchasedByСashbox;
            _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
        }

        public void CreateOrderByCustomer(CreateOrderInputModel order, string name)
        {
            SessionBLL sessionInNewOrder = _instanceMapperBll.MapSessionDtoToSessionBLL(_sessionRepository.GetSessionById(order.SessionId));
            SeatBLL seatInNewOrder = _instanceMapperBll.MapSeatDtoToSeatBLL(_seatRepository.GetSeatById(order.SeatsId));
            int secondPartCode = order.SessionId;
            int thirdPartCode = order.SeatsId;
            order.Code = CreateCode(secondPartCode, thirdPartCode);
            order.Date = DateTime.Now;
            order.User.UserName = name;
            order.Status = OrderStatus.PurchasedBySite;
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
  
