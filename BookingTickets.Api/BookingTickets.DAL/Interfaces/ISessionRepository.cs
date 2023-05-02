namespace BookingTickets.DAL.Interfaces
{
    public interface ISessionRepository
    {
        SessionDto CreateSession(SessionDto session);

        SessionDto GetSessionById(int sessionId);

        List<SessionDto> GetAllSession();

        List<SessionDto> GetAllSessionByFilmId(int idFilm);

        List<SessionDto> GetAllSessionByCinemaId(int idCinema);

        List<SessionDto> GetAllSessionByDate(DateTime date);

        List<SessionDto> GetAllSessionInTheIntervalDate(DateOnly dateStart, DateOnly dateEnd);

        void DeleteSession(int idSession);

    }
}