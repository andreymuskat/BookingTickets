using BookingTickets.BLL.Models;
using Core;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);

        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId);
        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm);

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId);

        public SessionBLL GetSessionByIdInHisCinema(int idSession);

        public OrderBLL FindOrderByCodeNumber(string codeNumber);

        public int GetCashiersCinemaId(UserBLL user);

        public void CreateOrder(OrderBLL order);

        public OrderStatus EditOrderStatus(OrderStatus status, string code);
    }
}
