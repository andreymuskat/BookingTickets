using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmById(int filmId);   
        
        public List<SessionBLL> GetFilmsByCinema(int cinemaId, DateTime time);

        public List<SessionBLL> GetSessionsByFilm(int idFilm, DateTime time);

        public List<CinemaBLL> GetCinemaByFilm(int idFilm);

        public SessionOutputModel GetSessionById(int idSession);

        public string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId);

        void CancelOrderByCustomer(string code);
    }
}
