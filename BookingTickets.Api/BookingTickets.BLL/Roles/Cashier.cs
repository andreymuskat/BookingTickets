using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Cashier : IСashier
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();

        private readonly FilmManager _filmManager;
        private readonly SessionManager _sessionManager;
        private readonly CinemaManager _cinemaManager;
        private const int advertisingTime = 15;
        public Cashier()
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
            _cinemaManager = new CinemaManager();
        }
        public FilmBLL GetFilmById(int filmId)
        {
            return _filmManager.GetFilmById(filmId);
        }

        public List<SessionBLL> GetFilmsInHisCinema()
        {
            //ЗАГЛУШКА
            var listSession = _sessionManager.GetAllSessionByCinema();
            var res = listSession.FindAll(d => d.IsDeleted == false);
            return res;
        }

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm)
        {
            //ЗАГЛУШКА
            var listSession = _sessionManager.GetAllSessionByFilmId(idFilm);
            var notDeleted = listSession.FindAll(d => d.IsDeleted == false);
            var res = notDeleted.FindAll(d => (d.Date).AddMinutes(advertisingTime) > DateTime.Now);
            return res;
        }

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(SessionBLL session)
        {
            //ЗАГЛУШКА
            var freeSeats = new List<SeatBLL>();
            return freeSeats;
        }

        public SessionBLL GetSessionByIdInHisCinema(int idSession)
        {
            //ЗАГЛУШКА
            var sb = _sessionManager.GetSessionById(idSession);
            if (sb.IsDeleted == false && sb.Date.AddMinutes(advertisingTime) > DateTime.Now)
            {
                return sb;
            }
            else
            {
                throw new Exception("������ ����� ������ ����������");
            }
        }
        public OrderBLL FindOrderByCodeNumber(int codeNumber)
        {
            //ЗАГЛУШКА
            var clientOrder = new OrderBLL();
            return clientOrder;
        }
    }
}
