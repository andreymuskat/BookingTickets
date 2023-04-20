using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmById(int id);   
        
        public List<SessionBLL> GetFilmsByCinema(int cinemaId);

        public List<CinemaBLL> GetCinemaByFilm(FilmBLL film);

        public List<SessionBLL> GetSessionsByFilm(FilmBLL film);

        public List<SeatBLL> GetFreeSeatsBySession(SessionBLL session);
    }
}
