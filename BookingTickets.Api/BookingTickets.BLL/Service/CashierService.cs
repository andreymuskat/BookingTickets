using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using BookingTickets.Core.CustomException;
using Core.Status;

namespace BookingTickets.BLL.Roles
{
    public class CashierService : ICashierService
    {
        private readonly IFilmManager _filmManager;
        private readonly ISessionManager _sessionManager;
        private readonly ICinemaManager _cinemaManager;
        private readonly IUserManager _userManager;
        private readonly IOrderManager _orderManager;
        private readonly ISeatManager _seatManager;

        public CashierService(ICinemaManager cinemaManager, ISessionManager sessionManager, IUserManager userManager, IFilmManager filmManager,
            IOrderManager orderManager, ISeatManager seatManager)
        {
            _filmManager = filmManager;
            _sessionManager = sessionManager;
            _cinemaManager = cinemaManager;
            _userManager = userManager;
            _orderManager = orderManager;
            _seatManager = seatManager;
        }

        public FilmBLL GetFilmById(int filmId)
        {
            return _filmManager.GetFilmById(filmId);
        }

        public List<SessionBLL> GetSessionsInHisCinema(int cashiersCinemaId)
        {
            var listSession = _sessionManager.GetAllSessionByCinemaId(cashiersCinemaId)
                .Where(k => k.IsDeleted == false)
                .ToList();

            if (listSession != null)
            {
                return listSession;
            }
            else
            {
                throw new SessionException(777);
            }
        }

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm, int cashiersCinemaId)
        {
            var listSession = _sessionManager.GetAllSessionByCinemaAndFilm(idFilm, cashiersCinemaId)
                .Where(k => k.IsDeleted == false)
                .ToList();
            if (listSession != null)
            {
                return listSession;
            }
            else
            {
                throw new SessionException(777);
            }
        }

        public SessionOutputModel GetSessionById(int idSession, int cashiersCinemaId)
        {
            var session = _sessionManager.GetSessionById(idSession);
            var cinema = _cinemaManager.GetCinemaByHallId(session.HallId);

            if (cinema.Id == cashiersCinemaId)
            {
                return session;
            }
            else
            {
                throw new SessionException(205);
            }
        }

        public List<SeatsForCashierOutputModel> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId)
        {
            var allSeats = _seatManager.GetFreeSeatsBySessionIdForCashier(sessionId);
            int hallId = allSeats.First().Hall.Id;
            var cinemaId = _cinemaManager.GetCinemaByHallId(hallId);

            if (cinemaId.Id == cashiersCinemaId)
            {
                return allSeats;
            }
            else
            {
                throw new SessionException(205);
            }
        }

        public List<OrderBLL> FindOrderByCodeNumber(string codeNumber)
        {
            var order = _orderManager.FindOrdersByCodeNumber(codeNumber);
            if (order != null)
            {
                return order;
            }
            else
            {
                throw new SessionException(777);
            }
        }

        public void CreateOrderByCashier(List<CreateOrderInputModel> orders, int cinemaId, int userId)
        {
            SessionBLL sess = _sessionManager.GetAllSessionByCinemaId(cinemaId)
                .Single(k => k.Id == orders[0].SessionId);

            if (sess != null)
            {
                _orderManager.CreateOrderByCashier(orders, userId);
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
            var cinemaInOrder = _cinemaManager.GetCinemaByHallId(orderBll.First().Seats.HallId);

            if (cinemaInOrder.Id == cinemaId)
            {
                _orderManager.EditOrderStatus(status, code);
            }
            else
            {
                throw new SessionException(205);
            }
        }
    }
}
