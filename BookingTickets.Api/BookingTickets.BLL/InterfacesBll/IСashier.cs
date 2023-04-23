using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);

        public List<SessionBLL> GetFilmsInHisCinema();

        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm);

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(SessionBLL session);

        public SessionBLL GetSessionByIdInHisCinema(int idSession);

        public OrderBLL FindOrderByCodeNumber(int codeNumber);
    }
}
