using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;
using Core;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);
        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber); 
        public void CreateOrderByCashier(CreateOrderInputModel order, int cinemaId, string name); 
        public SessionBLL GetSessionById(int idSession); 
        public void EditOrderStatus(OrderStatus status, string code, int cinemaId); 
        public List<SessionBLL> GetSessionsInHisCinema(int cashierId); 
        public List<SessionBLL> GetSessionsByFilmInHisCinema(int cashiersCinemaId, int filmId); 
        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId);
    }
}
