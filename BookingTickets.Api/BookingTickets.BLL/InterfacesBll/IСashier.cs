using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using Core;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);

        public List <OrderBLL> FindOrderByCodeNumber(string codeNumber); 

        public void CreateOrderByCashier(List<CreateOrderInputModel> orders, int cinemaId, int userId); 

        public SessionOutputModel GetSessionById(int idSession, int cashiersCinemaId); 

        public void EditOrderStatus(OrderStatus status, string code, int cinemaId); 

        public List<SessionBLL> GetSessionsInHisCinema(int cashierId); 

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int cashiersCinemaId, int filmId);

        public List<SeatsForCashierOutputModel> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId);
    }
}
