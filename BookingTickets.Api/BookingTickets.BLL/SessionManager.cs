using AutoMapper;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class SessionManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISessionRepository _sessionRepository;
        private readonly IFilmRepository _filmRepository;

        const int timeoutInMin = 30;

        public SessionManager()
        {
            _sessionRepository = new SessionRepository();
        }

        public void CreateSession(CreateSessionInputModel newSession)
        {
            TimeOnly TimeStartNewSession = TimeOnly.FromDateTime(newSession.Date);

            FilmDto filmDto = _filmRepository.GetFilmById(newSession.FilmId);

            FilmBLL FilmInNewSession = _instanceMapperBll.MapFilmDtoToFilmBLL(filmDto);

            TimeSpan DurationSession = TimeSpan.FromHours(FilmInNewSession.Duration + timeoutInMin);

            List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
            List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

            List<SessionBLL> AllSessionsInDate = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByDate(newSession.Date));

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
                    _sessionRepository.CreateSession(_instanceMapperBll.MapCreateSessionInputModelToSessionDto(newSession));
                }
            }
        }
    }
}
