using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SessionManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISessionRepository _sessionRepository;
        const int timeoutInMin = 30;

        public SessionManager()
        {
            _sessionRepository = new SessionRepository();
        }

        public void CreateSession(SessionBLL session)
        {
            var TimeOnlySession = TimeOnly.FromDateTime(session.Date);
            var DurationSession = TimeSpan.FromHours(session.Film.Duration + timeoutInMin);
            List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
            List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

            List<SessionBLL> AllSessionsInDate = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByDate(session.Date));

            for (int i = 0; i< AllSessionsInDate.Count; i++)
            {
                allTimeStartSession[i] = TimeOnly.FromDateTime(AllSessionsInDate[i].Date);
                allTimeEndSession[i] = TimeOnly.FromDateTime(AllSessionsInDate[i].Date.AddMinutes(timeoutInMin));

                var SubtractSession = allTimeStartSession[i] - TimeOnly.FromDateTime(session.Date);

                if (SubtractSession < DurationSession)
                {
                    throw new Exception("Длительность фильма превышет свободное время до следующего сеанса!");
                }
                else if(allTimeStartSession[i] < TimeOnlySession && TimeOnlySession > allTimeEndSession[i])
                {
                    throw new Exception("В это время уже идет сеанс!");
                }
                else
                {
                    _sessionRepository.CreateSession(_instanceMapperBll.MapSessionBLLToSessionDto(session));
                }
            }
        }
    }
}
