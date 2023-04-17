using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ISessionRepository
    {
        public SessionDto CreateSession(SessionDto session);

        public void UpdateSession(SessionDto session);

        public List<SessionDto> GetAllSession();

        public void DeleteSession(int idSession);

        public List<SessionDto> GetAllSessionByFilmId(int idFilm);

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema);

        public List<SessionDto> GetAllSessionByDate(DateTime Date);
    }
}