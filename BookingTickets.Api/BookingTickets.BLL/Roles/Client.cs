using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using Core;

namespace BookingTickets.BLL.Roles
{
    public class Client : IClient
    {
        private readonly FilmManager _filmManager;
        private readonly SessionManager _sessionManager;
        private readonly CinemaManager _cinemaManager;
        private readonly OrderManager _orderManager;
        private const int advertisingTime = 15;

        public Client()
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
            _cinemaManager = new CinemaManager();
            _orderManager = new OrderManager();
        }

        public FilmBLL GetFilmById(int id)
        {
            return _filmManager.GetFilmById(id);
        }

        public List<SessionBLL> GetFilmsByCinema(int cinemaId)
        {
            var listSession = _sessionManager.GetAllSessionByCinemaId(cinemaId);
            var res = listSession.FindAll(d => d.IsDeleted == false);
            return res;
        }

        public List<CinemaBLL> GetCinemaByFilm(int idFilm)
        {
            var listCinema = _cinemaManager.GetCinemaByFilm(idFilm);
            var res = listCinema.FindAll(d => d.IsDeleted == false);
            return res;
        }

        public List<SessionBLL> GetSessionsByFilm(int idFilm)
        {
            var listSession = _sessionManager.GetAllSessionByFilmId(idFilm);
            var notDeleted = listSession.FindAll(d => d.IsDeleted == false);
            var res = notDeleted.FindAll(d => (d.Date).AddMinutes(advertisingTime) > DateTime.Now);
            return res;
        }

        public List<SeatBLL> GetFreeSeatsBySession(int sessionId)
        {
            return new List<SeatBLL>();
        }

        public SessionBLL GetSessionById(int idSession)
        {
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
        public void CreateOrder(OrderBLL order)
        {
            _orderManager.CreateOrder(order);
        }
    }
}
