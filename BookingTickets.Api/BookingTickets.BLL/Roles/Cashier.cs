using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Authentication.AuthModels;

namespace BookingTickets.BLL.Roles
{
    public class Cashier : IСashier
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();

        private readonly FilmManager _filmManager;
        private readonly SessionManager _sessionManager;
        private readonly CinemaManager _cinemaManager;
        private readonly UserManager _userManager;
        private readonly OrderManager _orderManager;
        //private int cashiersCinemaId;
        private const int advertisingTime = 15;

        public Cashier(UserBLL userId)
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
            _cinemaManager = new CinemaManager();
            _userManager = new UserManager();
            //cashiersCinemaId = GetUserCinemaId(userId);
        }
        public FilmBLL GetFilmById(int filmId)
        {
            return _filmManager.GetFilmById(filmId);
        }

        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId)
        {
            var listSession = _sessionManager.GetAllSessionByCinemaId(cashiersCinemaId);
            var res = listSession.FindAll(d => d.IsDeleted == false);
            return res;
        }

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm)
        {
            var listSession = _sessionManager.GetAllSessionByFilmId(idFilm);
            var notDeleted = listSession.FindAll(d => d.IsDeleted == false);
            var cashierCinema = notDeleted.FindAll(k => k.Hall.Cinema.Id == cashiersCinemaId);
            var res = notDeleted.FindAll(d => (d.Date).AddMinutes(advertisingTime) > DateTime.Now);
            return res;
        }

        public SessionBLL GetSessionByIdInHisCinema(int idSession)
        {
            //ЗАГЛУШКА
            return new SessionBLL();

        }
        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(SessionBLL session)
        {
            //ЗАГЛУШКА
            var freeSeats = new List<SeatBLL>();
            return freeSeats;
        }

        public OrderBLL FindOrderByCodeNumber(string codeNumber)
        {
            var order = _orderManager.FindOrderByCodeNumber(codeNumber);
            return order;
        }
        public int GetCashiersCinemaId(UserBLL user)
        {
            int cashiersCinemaId = user.Cinema.Id;
            return cashiersCinemaId;
        }
    }
}
