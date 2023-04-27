namespace BookingTickets.DAL.Interfaces
{
    public interface ISessionRepository
    {
        public SessionDto CreateSession(SessionDto session);

        public SessionDto GetSessionById(int sessionId);

        public List<SessionDto> GetAllSession();

        public List<SessionDto> GetAllSessionByFilmId(int idFilm);

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema);

        public List<SessionDto> GetAllSessionByDate(DateTime Date);

        public void DeleteSession(int idSession);

    }
}