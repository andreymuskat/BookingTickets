using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.InterfacesBll.Service_Interfaces;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using BookingTickets.Core.CustomException;
using Core.ILogger;
using Core.Status;

namespace BookingTickets.BLL.Roles
{
    public class CashierService : ICashierService
    {
        private readonly INLogLogger _logger;
        private readonly IFilmManager _filmManager;
        private readonly ISessionManager _sessionManager;
        private readonly ICinemaManager _cinemaManager;
        private readonly IUserManager _userManager;
        private readonly IOrderManager _orderManager;
        private readonly ISeatManager _seatManager;

        public CashierService(INLogLogger logger, ICinemaManager cinemaManager, ISessionManager sessionManager, IUserManager userManager,
            IFilmManager filmManager, IOrderManager orderManager, ISeatManager seatManager)
        {
            _filmManager = filmManager;
            _sessionManager = sessionManager;
            _cinemaManager = cinemaManager;
            _userManager = userManager;
            _orderManager = orderManager;
            _seatManager = seatManager;
            _logger = logger;
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

            return listSession;
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
                _logger.Warn("Tried to create a session not in your cinema");

                throw new SessionException(205);
            }
        }

        public List<SeatsForCashierOutputModel> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId)
        {
            var cinemaId = _cinemaManager.GetCinemaBySessionId(sessionId);

            if (cinemaId.Id == cashiersCinemaId)
            {
                var allFreeSeats = _seatManager.GetFreeSeatsBySessionIdForCashier(sessionId);

                return allFreeSeats;
            }
            else
            {
                _logger.Warn("Search seats not in your cinema");

                throw new SeatException(205);
            }
        }

        public List<OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            var order = _orderManager.FindOrdersByCodeNumber(codeNumber);

            return order;
        }

        public List<OrderBLL> CreateOrderByCashier(List<CreateOrderInputModel> orders, int cinemaId, int userId)
        {
            DateTime nowData = DateTime.Now;
            SessionBLL sess = _sessionManager.GetAllSessionByCinemaId(cinemaId)
                .Single(k => k.Id == orders[0].SessionId);

            if (sess != null)
            {
                if (sess.Date >= nowData)
                {
                    var allNewOrders = _orderManager.CreateOrderByCashier(orders, userId);

                    return allNewOrders;
                }
                else
                {
                    _logger.Warn($"Tried create an order for the past session");

                    throw new OrderException(120);
                }
            }
            else
            {
                _logger.Warn("Tried to create a session not in your cinema");

                throw new OrderException(205);
            }
        }

        public void EditOrderStatus(OrderStatus status, string code, int cinemaId)
        {
            DateTime nowData = DateTime.Now;
            var orderBll = _orderManager.FindOrdersByCodeNumber(code);
            var cinemaInOrder = _cinemaManager.GetCinemaByHallId(orderBll.First().Seats.HallId);

            if (cinemaInOrder.Id == cinemaId)
            {
                if (orderBll.FirstOrDefault(k => k.User != null)!.Session.Date >= nowData)
                {
                    if (status != OrderStatus.Booking && status != OrderStatus.PurchasedBySite)
                    {
                        _orderManager.EditOrderStatus(status, code);
                    }
                    else
                    {
                        _logger.Warn("Attempt to change order status");

                        throw new OrderException(333);
                    }
                }
                else
                {
                    _logger.Warn($"Tried change order status for the past session");

                    throw new OrderException(120);
                }
            }
            else
            {
                _logger.Warn("Tried to create a session not in your cinema");

                throw new OrderException(205);
            }
        }
    }
}
