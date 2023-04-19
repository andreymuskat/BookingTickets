using AutoMapper;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SessionManager
    {
        private readonly IMapper _mapper;
        private readonly ISessionRepository _sessionRepository;
        private readonly IFilmRepository _filmRepository;

        const int timeoutInMin = 30;

        public SessionManager(IMapper map)
        {
            _mapper = map;
            _sessionRepository = new SessionRepository();
        }

        public void CreateSession(CreateSessionInputModel newSession)
        {
            TimeOnly TimeStartNewSession = TimeOnly.FromDateTime(newSession.Date);

            FilmBLL FilmInNewSession = _mapper.Map<FilmBLL>(_filmRepository.GetFilmById(newSession.FilmId));

            TimeSpan DurationSession = TimeSpan.FromHours(FilmInNewSession.Duration + timeoutInMin);

            List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
            List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

            List<SessionBLL> AllSessionsInDate = _mapper.Map<List<SessionBLL>>(_sessionRepository.GetAllSessionByDate(newSession.Date));

            for (int i = 0; i < AllSessionsInDate.Count; i++)
            {
                allTimeStartSession[i] = TimeOnly.FromDateTime(AllSessionsInDate[i].Date);
                allTimeEndSession[i] = allTimeStartSession[i].AddMinutes(AllSessionsInDate[i].Film.Duration + timeoutInMin);

                var SubtractSession = allTimeStartSession[i] - TimeOnly.FromDateTime(newSession.Date);

                if (SubtractSession < DurationSession)
                {
                    throw new Exception("Длительность фильма превышет свободное время до следующего сеанса!");
                }
                else if (allTimeStartSession[i] < TimeStartNewSession 
                    && TimeStartNewSession > allTimeEndSession[i])
                {
                    throw new Exception("В это время уже идет сеанс!");
                }
                else
                {
                    _sessionRepository.CreateSession(_mapper.Map<SessionDto>(newSession));
                }
            }
        }
    }
}
