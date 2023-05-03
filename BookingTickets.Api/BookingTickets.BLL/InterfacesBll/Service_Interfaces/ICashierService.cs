using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll.Service_Interfaces
{
    public interface ICashierService
    {
        List<OrderBLL> CreateOrderByCashier(List<CreateOrderInputModel> orders, int cinemaId, int userId);

        void EditOrderStatus(OrderStatus status, string code, int cinemaId);

        List<OrderBLL> FindOrdersByCodeNumber(string codeNumber);

        FilmBLL GetFilmById(int filmId);

        List<SeatsForCashierOutputModel> GetFreeSeatsBySessionInHisCinema(int sessionId, int cashiersCinemaId);

        SessionOutputModel GetSessionById(int idSession, int cashiersCinemaId);

        List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm, int cashiersCinemaId);

        List<SessionBLL> GetSessionsInHisCinema(int cashiersCinemaId);
    }
}