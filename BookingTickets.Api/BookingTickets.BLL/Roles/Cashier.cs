using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using BookingTickets.BLL.Models.All_SessionBLLModel;
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
        private readonly SeatManager _seatManager;
        private const int advertisingTime = 15;

        public Cashier()
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
            _cinemaManager = new CinemaManager();
            _userManager = new UserManager();
            _orderManager = new OrderManager();
            _seatManager = new SeatManager();
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

        public SessionBLL GetSessionById(int idSession)
        {
                var allSession = _sessionManager.GetSessionById(idSession);
                if (allSession.IsDeleted == false && allSession.Date.AddMinutes(advertisingTime) > DateTime.Now)
                {
                    return allSession;
                }
                else
                {
                    throw new SessionException(205);
                }

            return allSession;
        }
        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId)
        {
            var allSeats = _seatManager.GetFreeSeatsBySessionId(sessionId);
            int hallId = allSeats.SingleOrDefault().HallId;
            var cinemaId=_cinemaManager.GetCinemaByHallId(hallId);
            if (cinemaId.Id == cashiersCinemaId)
            {
                return allSeats;
            }
            else
            {
                throw new SessionException(205);
            }
        }
        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber)
        {
            var order = _orderManager.FindOrdersByCodeNumber(codeNumber);
            return order;
        }
        public int GetCashiersCinemaId(UserBLL user)
        {
            int cashiersCinemaId = user.Cinema.Id;
            return cashiersCinemaId;
        }

        public void CreateOrderByCashier(CreateOrderInputModel order,int requestedCinemaId, int cinemaId, string name)
        {
                if (requestedCinemaId==cinemaId)
            {
                _orderManager.CreateOrderByCashier(order, cinemaId,  name);
            }
                else
            {
                throw new SessionException(205);
            }
        }

        public void CreateSession(CreateSessionInputModel session, int cinemaId)
        {
            var cinemaBll = _cinemaManager.GetCinemaByHallId(session.HallId);

            if (cinemaBll.Id == cinemaId)
            {
                _sessionManager.CreateSession(session);
            }
            else
            {
                throw new SessionException(205);
            }
        }

        public void EditOrderStatus(OrderStatus status, string code, int cinemaId)
        {
            var orderBll = _orderManager.FindOrdersByCodeNumber(code);
            var cinemaIdInOrder = orderBll.SingleOrDefault().Session.Hall.Cinema.Id;

            if (cinemaIdInOrder == cinemaId)
            {
             _orderManager.EditOrderStatus(status, code);
            }
            else
            {
                throw new SessionException(205);
            }
        }
        public List<SessionBLL> GetSessionsInHisCinema(int cashierId)
        {
            var allSession = _sessionManager.GetAllSessionByCinemaId(cashierId);
            return allSession;
        }
    }
}
