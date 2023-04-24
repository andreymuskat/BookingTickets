using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

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
            _filmRepository = new FilmRepository();
        }

        public void CreateSession(CreateSessionInputModel newSession)
        {
            TimeOnly TimeStartNewSession = TimeOnly.FromDateTime(newSession.Date);
            FilmBLL FilmInNewSession = _instanceMapperBll.MapFilmDtoToFilmBLL(_filmRepository.GetFilmById(newSession.FilmId));

            TimeSpan DurationSession = TimeSpan.FromMinutes(FilmInNewSession.Duration + timeoutInMin);

            List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
            List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

            List<SessionBLL> AllSessionsInDate = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByDate(newSession.Date));

            if (AllSessionsInDate.Count > 0)
            {
                for (int i = 0; i < AllSessionsInDate.Count; i++)
                {
                    allTimeStartSession.Add(TimeOnly.FromDateTime(AllSessionsInDate[i].Date));
                    allTimeEndSession.Add(allTimeStartSession[i].AddMinutes(FilmInNewSession.Duration + timeoutInMin));

                    var SubtractSession = allTimeStartSession[i] - TimeOnly.FromDateTime(newSession.Date);

                    if (allTimeStartSession[i] <= TimeStartNewSession
                        || TimeStartNewSession >= allTimeEndSession[i])
                    {
                        throw new Exception("В это время уже идет сеанс!");
                    }
                    else if (SubtractSession < DurationSession)
                    {
                        throw new Exception("Длительность фильма превышет свободное время до следующего сеанса!");
                    }
                    else
                    {
                        _sessionRepository.CreateSession(_instanceMapperBll.MapCreateSessionInputModelToSessionDto(newSession));
                    }
                }
            }
            else
            {
                _sessionRepository.CreateSession(_instanceMapperBll.MapCreateSessionInputModelToSessionDto(newSession));
            }
        }

        public void DeleteSession(int idSession)
        {
            var sess = _sessionRepository.GetSessionById(idSession);

            if (sess != null)
            {
                _sessionRepository.DeleteSession(idSession);
            }
            else { throw new Exception("Сессия, которую вы пытаетесь удалить, не найдена в базе!"); }
        }

        public List<SessionBLL> GetAllSessionByCinemaId(int idCinema)
        {
            return _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByCinemaId(idCinema));
        }

        public List<SessionBLL> GetAllSessionByFilmId(int idFilm)
        {
            var listSessionDto = _sessionRepository.GetAllSessionByFilmId(idFilm);
            var listSessionBLL = _instanceMapperBll.MapListSessionDtoToListSessionBLL(listSessionDto);
            return listSessionBLL;
        }

        public SessionBLL GetSessionById(int idSession)
        {
            var sDto = _sessionRepository.GetSessionById(idSession);
            var res = _instanceMapperBll.MapSessionDtoToSessionBLL(sDto);
            return res;
        }

        //public List<SessionDto> GetFilmsInHisCinema(UserDto userId)
        //{

        //}

    }
}
