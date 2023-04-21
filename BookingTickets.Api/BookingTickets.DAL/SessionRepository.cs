using BookingTickets.DAL.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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
            try
            {
               var res = _context.Sessions.FirstOrDefault(i => i.Id == sessionId);
                return res;
            }
            catch
            {                
                throw new Exception ("BadRequest");
            }
        }

        public List<SessionDto> GetAllSession()
        {
            return new List<SessionDto>();
        }

        public List<SessionDto> GetAllSessionByFilmId(int idFilm)
        {
            var list = _context.Sessions.Where(k => k.IsDeleted == false).Where(f=>f.Id == idFilm).ToList();            
            return list;
        }

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema)
        {
            return _context.Sessions
                .Where(k => k.Hall.Cinema.Id == idCinema)
                .ToList();
        }

        public List<SessionDto> GetAllSessionByDate(DateTime Date)
        {
            List<SessionDto> AllSession = _context.Sessions
                .Where(k => k.IsDeleted == false)
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

        public void DeleteSession(int idSession)
        {
            var sess = _context.Sessions.Single(i => i.Id == idSession).IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
