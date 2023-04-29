using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using Core;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);

        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId);
        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm, int cashiersCinemaId);

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId);

        public SessionBLL GetSessionByIdInHisCinema(int idSession);

        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber);

        public int GetCashiersCinemaId(UserBLL user);

        public void CreateOrder(CreateOrderInputModel order, int cinemaId, string name);

        public void EditOrderStatus(OrderStatus status, string code);
    }
}
