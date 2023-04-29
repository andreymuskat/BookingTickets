using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using Core;

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
        private const int advertisingTime = 15;

        public Cashier()
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
            _cinemaManager = new CinemaManager();
            _userManager = new UserManager();
            _orderManager = new OrderManager();
        }
        public FilmBLL GetFilmById(int filmId)
        {
            return _filmManager.GetFilmById(filmId);
        }

        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId)
        {
            int cashiersCinemaId = userId.Cinema.Id;
            var listSession = _sessionManager.GetAllSessionByCinemaId(cashiersCinemaId);
            var res = listSession.FindAll(d => d.IsDeleted == false);
            return res;
        }

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm, int cashiersCinemaId)
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
        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId)
        {
            //ЗАГЛУШКА
            var freeSeats = new List<SeatBLL>();
            return freeSeats;
        }

        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber)
        {
            var order = _orderManager.FindOrderByCodeNumber(codeNumber);
            return order;
        }
        public int GetCashiersCinemaId(UserBLL user)
        {
            int cashiersCinemaId = user.Cinema.Id;
            return cashiersCinemaId;
        }

        public void CreateOrder(CreateOrderInputModel order, int cinemaId,string name)
        {
            _orderManager.CreateOrder(order);
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
             _orderManager.EditOrderStatus(status, code);
        }
    }
}
