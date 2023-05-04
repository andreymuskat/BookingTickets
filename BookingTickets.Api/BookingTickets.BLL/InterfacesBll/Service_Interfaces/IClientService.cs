using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;

namespace BookingTickets.BLL.InterfacesBll.Service_Interfaces
{
    public interface IClientService
    {
        void CancelOrderByCustomer(string code);
        string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId);
        public List<CinemaBLL> GetCinemaByFilm(int idFilm);
        FilmBLL GetFilmById(int id);
        List<SessionBLL> GetFilmsByCinema(int cinemaId, DateTime time);
        SessionOutputModel GetSessionById(int idSession);
        List<SessionBLL> GetSessionsByFilm(int idFilm, DateTime time);
    }
}