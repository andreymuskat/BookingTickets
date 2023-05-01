using BookingTickets.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class SessionRepository : ISessionRepository
    {
        private readonly Context _context;

        public SessionRepository()
        {
            _context = new Context();
        }

        public SessionDto CreateSession(SessionDto session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public SessionDto GetSessionById(int sessionId)
        {
            return _context.Sessions.Where(s => s.IsDeleted == false).FirstOrDefault(i => i.Id == sessionId);
        }

        public List<SessionDto> GetAllSession()
        {
            return new List<SessionDto>();
        }

        public List<SessionDto> GetAllSessionByFilmId(int idFilm)
        {
            var x = _context.Sessions.Where(f => f.FilmId == idFilm).ToList();
            return x;
        }

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema)
        {
            var sessions = _context.Sessions
            .Where(k => k.Hall.Cinema.Id == idCinema && k.IsDeleted == false)
            .ToList();
            return sessions;
        }

        public List<SessionDto> GetAllSessionByDate(DateTime date)
        {
            List<SessionDto> SessionInDay = new List<SessionDto>();
            List<SessionDto> AllSession = _context.Sessions
                .Where(k => k.IsDeleted == false)
                .Include(k => k.Film)
                .Include(h => h.Hall)
                .ToList();

            DateOnly dateSearch = DateOnly.FromDateTime(date);
            for (int i = 0; i < AllSession.Count; i++)
            {
                DateOnly session = DateOnly.FromDateTime(AllSession[i].Date);
                if (session == dateSearch)
                {
                    SessionInDay.Add(AllSession[i]);
                }
            }
            return SessionInDay;
        }

        public List<SessionDto> GetAllSessionByDateWithDeleted(DateTime Date)
        {
            List<SessionDto> AllSession = _context.Sessions
                .ToList();

            DateOnly dateSearch = DateOnly.FromDateTime(Date);
            List<SessionDto> SessionInDay = new List<SessionDto>();

            for (int i = 0; i < AllSession.Count; i++)
            {
                DateOnly session = DateOnly.FromDateTime(AllSession[i].Date);
                if (session == dateSearch)
                {
                    SessionInDay.Add(AllSession[i]);
                }
            }
            return SessionInDay;
        }

        public List<SessionDto> GetAllSessionInTheIntervalDate(DateOnly dateStart, DateOnly dateEnd)
        {
            List<SessionDto> SessionInTheInterval = new List<SessionDto>();
            List<SessionDto> AllSession = _context.Sessions
                .Where(k => k.IsDeleted == false)
                .Include(k => k.Film)
                .Include(h => h.Hall)
                .ToList();

            for (int i = 0; i < AllSession.Count; i++)
            {
                DateOnly session = DateOnly.FromDateTime(AllSession[i].Date);
                if (dateStart <= session && session <= dateEnd)
                {
                    SessionInTheInterval.Add(AllSession[i]);
                }
            }

            return SessionInTheInterval;
        }

        public void DeleteSession(int idSession)
        {
            var sess = _context.Sessions.Single(i => i.Id == idSession).IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
