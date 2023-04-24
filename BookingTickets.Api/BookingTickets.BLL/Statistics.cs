using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class Statistics
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ISessionRepository _sessionRepository;

        public Statistics()
        {
            _orderRepository = new OrderRepository();
            _seatRepository = new SeatRepository();
            _sessionRepository = new SessionRepository();
        }

        public void GetStatisticFilmsInCinema(int cinemaId)
        {
            List<SeatBLL> AllSeats = new List<SeatBLL>();

            List<SessionBLL> AllSessionThisFilm = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByCinemaId(cinemaId));

            
        }
    }
}
