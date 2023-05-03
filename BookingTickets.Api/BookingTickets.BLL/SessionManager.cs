using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using Core.ILogger;
using NLog;

namespace BookingTickets.BLL
{
    public class SessionManager : ISessionManager
    {
        private readonly INLogLogger _logger;
        private readonly ISessionRepository _sessionRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        const int timeoutInMin = 30;

        public SessionManager(IMapper map, ISessionRepository sessionRepository, IFilmRepository filmRepository, INLogLogger logger)
        {
            _sessionRepository = sessionRepository;
            _filmRepository = filmRepository;
            _mapper = map;
            _logger = logger;
        }

        public void CreateSession(CreateSessionInputModel newSession)
        {
            int SaveNewSession = 0;
            TimeOnly TimeStartNewSession = TimeOnly.FromDateTime(newSession.Date);
            var FilmInNewSession = _mapper.Map<FilmBLL>(_filmRepository.GetFilmById(newSession.FilmId));

            TimeSpan DurationSession = TimeSpan.FromMinutes(FilmInNewSession.Duration + timeoutInMin);

            List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
            List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

            var AllSessionsInDateDTO = _sessionRepository.GetAllSessionByDate(newSession.Date).Where(k => k.HallId == newSession.HallId).ToList();
            var AllSessionsInDate = _mapper.Map<List<SessionBLL>>(AllSessionsInDateDTO);

            if (AllSessionsInDate.Count > 0)
            {
                for (int i = 0; i < AllSessionsInDate.Count; i++)
                {
                    allTimeStartSession.Add(TimeOnly.FromDateTime(AllSessionsInDate[i].Date));
                    allTimeEndSession.Add(allTimeStartSession[i].AddMinutes(FilmInNewSession.Duration + timeoutInMin));

                    var SubtractSession = allTimeStartSession[i] - TimeOnly.FromDateTime(newSession.Date);

                    if (allTimeStartSession[i] <= TimeStartNewSession
                        && TimeStartNewSession <= allTimeEndSession[i])
                    {
                        _logger.Warn($"User tried to create a session at a time where there was already a record.");

                        throw new SessionException(100);
                    }
                    else if (SubtractSession < DurationSession)
                    {
                        _logger.Warn($"User tried to create a session where there was not enough time before the next session.");

                        throw new SessionException(101);
                    }
                    else
                    {
                        SaveNewSession++;
                    }
                }
            }
            else
            {
                _sessionRepository.CreateSession(_mapper.Map<SessionDto>(newSession));
            }

            if (SaveNewSession > 0)
            {
                _sessionRepository.CreateSession(_mapper.Map<SessionDto>(newSession));
            }
        }

        public void DeleteSession(int idSession)
        {
            var sess = _sessionRepository.GetSessionById(idSession);

            if (sess != null)
            {
                _sessionRepository.DeleteSession(idSession);
            }
            else { throw new SessionException(777); }
        }

        public List<SessionBLL> GetAllSessionByCinemaId(int idCinema)
        {

            var session = _mapper.Map<List<SessionBLL>>(_sessionRepository.GetAllSessionByCinemaId(idCinema));
            if (session != null)
            {
                return session;
            }
            else { throw new SessionException(777); }
        }

        public List<SessionBLL> GetAllSessionByFilmId(int idFilm)
        {
            var listSessionDto = _sessionRepository.GetAllSessionByFilmId(idFilm);
            var listSessionBLL = _mapper.Map<List<SessionBLL>>(listSessionDto);

            return listSessionBLL;
        }

        public SessionOutputModel GetSessionById(int idSession)
        {
            var sDto = _sessionRepository.GetSessionById(idSession);
            var res = _mapper.Map<SessionOutputModel>(sDto);

            return res;
        }

        public List<SessionBLL> GetAllSessionByCinemaAndFilm(int cinemaId, int filmId)
        {
            List<SessionDto> allSession = _sessionRepository.GetAllSessionByCinemaId(cinemaId)
                .Where(k => k.Film.Id == filmId)
                .ToList();

            var allSessionByFilm = _mapper.Map<List<SessionBLL>>(allSession);

            return allSessionByFilm;
        }
    }
}
