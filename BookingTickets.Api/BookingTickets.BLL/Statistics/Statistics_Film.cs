using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL.Statistics
{
    public class Statistics_Film
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly ISessionRepository _sessionRepository;

        public Statistics_Film()
        {
            _orderRepository = new OrderRepository();
            _seatRepository = new SeatRepository();
            _sessionRepository = new SessionRepository();
        }

        public int PercentNotPurchasedTicketsOnFilm(int cinemaId, int filmId)
        {
            int pctNotPurchasedTickets = 0;
            List<SeatBLL> AllSeats = new List<SeatBLL>();
            List<SeatBLL> NotBuySeats = new List<SeatBLL>();

            var AllSessionThisCinema = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByCinemaId(cinemaId));
            var AllSessionThisFilm = AllSessionThisCinema
                .Where(t => t.Film.Id == filmId)
                .Where(t => t.Date < DateTime.Now)
                .ToList();

            for (int i = 0; i < AllSessionThisFilm.Count; i++)
            {
                ////look at me
                var s = AllSessionThisFilm[i].Hall.Id;
                var p = _seatRepository.GetAllSeatInHall(s);
                var SeatsInHall = _instanceMapperBll.MapListSeatDtoToListSeatBLL(p);
                AllSeats.AddRange(SeatsInHall);

                ////and this
                var NotBuySeatsInHall = _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllFreeSeatsBySessionId(AllSessionThisFilm[i].Id));
                NotBuySeats.AddRange(NotBuySeatsInHall);
            }

            var ss = Convert.ToDouble(NotBuySeats.Count) / Convert.ToDouble(AllSeats.Count);
            pctNotPurchasedTickets = Convert.ToInt32(ss * 100);

            return pctNotPurchasedTickets;
        }

        public int PercentPurchasedTicketsOnFilm(int cinemaId, int filmId)
        {
            int pctPurchasedTickets = 0;

            int pctNotPurchasedTickets = PercentNotPurchasedTicketsOnFilm(cinemaId, filmId);

            pctPurchasedTickets = 100 - pctNotPurchasedTickets;

            return pctPurchasedTickets;
        }
    }
}
