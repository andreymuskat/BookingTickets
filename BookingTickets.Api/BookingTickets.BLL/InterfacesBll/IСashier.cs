using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IСashier
    {
        public FilmBLL GetFilmById(int filmId);

        public List<SessionBLL> GetSessionsInHisCinema(UserBLL userId);
        public List<SessionBLL> GetSessionsByFilmInHisCinema(int idFilm);

        public List<SeatBLL> GetFreeSeatsBySessionInHisCinema(int sessionId);

        //public List<SeatBLL> GetFreeSeatsBySession(int sessionId);
        public SessionBLL GetSessionByIdInHisCinema(int idSession);


        public OrderBLL FindOrderByCodeNumber(string codeNumber);

        public int GetCashiersCinemaId(UserBLL user);
    }
}
