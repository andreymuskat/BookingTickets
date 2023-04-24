using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmById(int filmId);   
        
        public List<SessionBLL> GetFilmsByCinema(int cinemaId);

        public List<CinemaBLL> GetCinemaByFilm(int idFilm);

        public List<SessionBLL> GetSessionsByFilm(int idFilm);

        public List<SeatBLL> GetFreeSeatsBySession(SessionBLL session);

        public SessionBLL GetSessionById(int idSession);
    }
}
