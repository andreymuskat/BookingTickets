using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Statistics
{
    public class Statistics_Film
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly SeatManager _seatManager;
        private readonly SessionManager _sessionManager;

        public Statistics_Film()
        {
            _seatManager = new SeatManager();
            _sessionManager = new SessionManager();
        }

        public int AmountTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountTickets = 0;
            List<SeatBLL> AllSeats = new List<SeatBLL>();
            List<SessionBLL> AllSession = _sessionManager.GetAllSessionByCinemaAndFilm(cinemaId, filmId);

            for (int i = 0; i < AllSession.Count; i++)
            {
                var dateThisSession = DateOnly.FromDateTime(AllSession[i].Date);

                if (dateStart <= dateThisSession && dateThisSession <= dateEnd)
                {
                    var SeatsInSession = _seatManager.GetAllSeatsBySessionId(AllSession[i].Id);
                    AllSeats.AddRange(SeatsInSession);
                }
            }

            AmountTickets = AllSeats.Count;

            return AmountTickets;
        }

        public int NotPurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountNotPurchasedTickets = 0;
            List<SeatBLL> NotBuySeats = new List<SeatBLL>();
            List<SessionBLL> AllSession = _sessionManager.GetAllSessionByCinemaAndFilm(cinemaId, filmId);

            for (int i = 0; i < AllSession.Count; i++)
            {
                var dateThisSession = DateOnly.FromDateTime(AllSession[i].Date);

                if (dateStart <= dateThisSession && dateThisSession <= dateEnd)
                {
                    var NotBuySeatsInHall = _seatManager.GetFreeSeatsBySessionId(AllSession[i].Id);
                    NotBuySeats.AddRange(NotBuySeatsInHall);
                }
            }

            AmountNotPurchasedTickets = NotBuySeats.Count;

            return AmountNotPurchasedTickets;
        }

        public int PurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            int AmountPurchasedTickets = 0;
            List<SeatBLL> AllPurchasedSeats = new List<SeatBLL>();
            List<SessionBLL> AllSession = _sessionManager.GetAllSessionByCinemaAndFilm(cinemaId, filmId);

            for (int i = 0; i < AllSession.Count; i++)
            {
                var dateThisSession = DateOnly.FromDateTime(AllSession[i].Date);

                if (dateStart <= dateThisSession && dateThisSession <= dateEnd)
                {
                    var PurchasedSeats = _seatManager.GetPurchasedSeatsBySessionId(AllSession[i].Id);
                    AllPurchasedSeats.AddRange(PurchasedSeats);
                }
            }

            AmountPurchasedTickets = AllPurchasedSeats.Count;

            return AmountPurchasedTickets;
        }

        public decimal BoxOfficeOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd)
        {
            decimal BoxOffice = 0;
            List<SessionBLL> AllSession = _sessionManager.GetAllSessionByCinemaAndFilm(cinemaId, filmId);
            List<SeatBLL> AllPurchasedSeats = new List<SeatBLL>();

            for (int i = 0; i < AllSession.Count; i++)
            {
                var dateThisSession = DateOnly.FromDateTime(AllSession[i].Date);

                if (dateStart <= dateThisSession && dateThisSession <= dateEnd)
                {
                    var costSession = AllSession[i].Cost;
                    var PurchasedSeats = _seatManager.GetPurchasedSeatsBySessionId(AllSession[i].Id);

                    BoxOffice += (costSession * PurchasedSeats.Count);
                }
            }

            return BoxOffice;
        }
    }
}
