using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmById(int filmId);   
        
        public List<SessionBLL> GetFilmsByCinema(int cinemaId);

        public List<CinemaBLL> GetCinemaByFilm(FilmBLL film);

        public List<SessionBLL> GetSessionsByFilm(FilmBLL film);

        public List<SeatBLL> GetFreeSeatsBySession(SessionBLL session);
    }
}
