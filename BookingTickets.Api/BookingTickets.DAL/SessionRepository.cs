using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL
{
    public class SessionRepository: ISessionRepository
    {
        private readonly Context _context;

        public SessionRepository ()
        {
            _context = new Context();
        }
        public SessionDto CreateSession(SessionDto session)
        { 
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public List<SessionDto> GetAllSession()
        {
            return new List<SessionDto>();
        }

        public void UpdateSession(SessionDto session)
        {

        }

        public List<SessionDto> GetAllSessionByFilmId(int idFilm)
        {
            return new List<SessionDto>();
        }

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema)
        {
            return new List<SessionDto>();
        }
        public List<SessionDto> GetAllSessionByDate(DateTime Date)
        {
            return new List<SessionDto>();
        }
        public void DeleteSession(int idSession)
        {

        }
    }
}
