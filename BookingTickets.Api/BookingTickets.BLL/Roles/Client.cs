using BookingTickets.Core.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using Core.Status;

namespace BookingTickets.BLL.Roles
{
    public class Client : IClient
    {
        private readonly IFilmManager _filmManager;
        private readonly ISessionManager _sessionManager;
        private readonly ICinemaManager _cinemaManager;
        private readonly IOrderManager _orderManager;

        private const int advertisingTime = 15;

        public Client(ICinemaManager cinemaManager, ISessionManager sessionManager, IOrderManager orderManager, IFilmManager filmManager)
        {
            _filmManager = filmManager;
            _sessionManager = sessionManager;
            _cinemaManager = cinemaManager;
            _orderManager = orderManager;
        }

        public FilmBLL GetFilmById(int id)
        {
            return _filmManager.GetFilmById(id);
        }

        public List<SessionBLL> GetFilmsByCinema(int cinemaId, DateTime time)
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

        public List<SessionBLL> GetSessionsByFilm(int idFilm, DateTime time)
        {
            DateTime EndTime = time.AddDays(1).AddHours(3);
            var listSession = _sessionManager.GetAllSessionByFilmId(idFilm);
            var notDeleted = listSession.FindAll(d => d.IsDeleted == false);
            var res = notDeleted.FindAll(d => (d.Date).AddMinutes(advertisingTime) > DateTime.Now && (d.Date)< EndTime);

            return res;
        }

        public SessionOutputModel GetSessionById(int idSession)
        {
            var sb = _sessionManager.GetSessionById(idSession);
            if (sb.Date.AddMinutes(advertisingTime) > DateTime.Now )
            {
                return sb;
            }
            else
            {
                throw new SessionException(205);
            }
        }

        public string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId)
        {
            var code =_orderManager.CreateOrderByCustomer(orders, userId);

            return code;
        }

        public void CancelOrderByCustomer(string code)
        {
            _orderManager.EditOrderStatus(OrderStatus.Canceled, code);
        }
    }
}
