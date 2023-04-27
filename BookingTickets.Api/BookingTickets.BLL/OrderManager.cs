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

        public OrderBLL FindOrderByCodeNumber(string codeNumber)
        {
            return _instanceMapperBll.MapOrderDtoToOrderBll(_orderRepository.FindOrderByCodeNumber(codeNumber));
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
            sessionInNewOrder. = code;
            if (order.User.UserStatus == UserStatus.Cashier)
            {
                order.Status = OrderStatus.PurchasedByСashbox;
            }
            //else if (order.User.UserStatus == UserStatus.Client)
            //{
            //    order.Status = OrderStatus.Booking;
            //}
            //_orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
        }

        //        {
        //    TimeOnly TimeStartNewSession = TimeOnly.FromDateTime(newSession.Date);
        //FilmBLL FilmInNewSession = _instanceMapperBll.MapFilmDtoToFilmBLL(_filmRepository.GetFilmById(newSession.FilmId));

        //TimeSpan DurationSession = TimeSpan.FromMinutes(FilmInNewSession.Duration + timeoutInMin);

        //List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
        //List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

        //List<SessionBLL> AllSessionsInDate = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByDate(newSession.Date));


        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.FindOrderByCodeNumber(code).Status = status;   
        }
    }

}
  
