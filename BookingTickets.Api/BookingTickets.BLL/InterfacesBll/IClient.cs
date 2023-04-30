using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_OrderBLLModel;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmById(int filmId);   
        
        public List<SessionBLL> GetFilmsByCinema(int cinemaId);

        public List<CinemaBLL> GetCinemaByFilm(int idFilm);

        public List<SessionBLL> GetSessionsByFilm(int idFilm);

        public List<SeatBLL> GetFreeSeatsBySession(int sessionId);

        //public SessionBLL GetSessionById(int idSession);

        public void CreateOrderByCustomer(CreateOrderInputModel order, int userId);
    }
}
