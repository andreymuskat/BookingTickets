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

        public int NotPurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountNotPurchasedTickets = 0;
            List<SeatBLL> NotBuySeats = new List<SeatBLL>();
            List<SessionBLL> AllSession = new List<SessionBLL>();

            AllSession = _instanceMapperBll.MapListSessionDtoToListSessionBLL
                (_sessionRepository.GetAllSessionInTheIntervalDate(dateStart, dateEnd)
                .Where(k => k.Film.Id == filmId)
                .Where(k => k.Hall.CinemaId == cinemaId)
                .ToList());

            for (int i = 0; i < AllSession.Count; i++)
            {
                var NotBuySeatsInHall = _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllFreeSeatsBySessionId(AllSession[i].Id));
                NotBuySeats.AddRange(NotBuySeatsInHall);
            }

            AmountNotPurchasedTickets = NotBuySeats.Count;

            return AmountNotPurchasedTickets;
        }

        public int PurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountPurchasedTickets = 0;
            List<SeatBLL> AllPurchasedSeats = new List<SeatBLL>();
            List<SessionBLL> AllSession = new List<SessionBLL>();

            AllSession = _instanceMapperBll.MapListSessionDtoToListSessionBLL
                (_sessionRepository.GetAllSessionInTheIntervalDate(dateStart, dateEnd)
                .Where(k => k.Film.Id == filmId)
                .Where(k => k.Hall.CinemaId == cinemaId)
                .ToList());

            for(int i = 0; i < AllSession.Count; i++)
            {
                var PurchasedSeats = _instanceMapperBll.MapListSeatDtoToListSeatBLL
                    (_seatRepository.GetAllPurchasedSeatsBySessionId(AllSession[i].Id));

                AllPurchasedSeats.AddRange(PurchasedSeats);
            }

            AmountPurchasedTickets = AllPurchasedSeats.Count;

            return AmountPurchasedTickets;
        }

        public int AmountTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountTickets = 0;
            List<SessionBLL> AllSession = new List<SessionBLL>();
            List<SeatBLL> AllSeats = new List<SeatBLL>();

            AllSession = _instanceMapperBll.MapListSessionDtoToListSessionBLL
                (_sessionRepository.GetAllSessionInTheIntervalDate(dateStart, dateEnd)
                .Where(k => k.Film.Id == filmId)
                .Where(k => k.Hall.CinemaId == cinemaId)
                .ToList());

            for (int i = 0; i < AllSession.Count; i++)
            {
                var SeatsInSession = _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllSeatsBySessionId(AllSession[i].Id));
                AllSeats.AddRange(SeatsInSession);
            }

            AmountTickets = AllSeats.Count;

            return AmountTickets;
        }
    }
}
