using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class HallManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IHallRepository _repository;
        public HallManager()
        {
            _repository = new HallRepository();
        }

        public void CreateHall(HallBLL hall)
        {
            _repository.CreateHall(_instanceMapperBll.MapHallBLLModelToHallDto(hall));
        }

        //var TimeOnlySession = TimeOnly.FromDateTime(session.Date);
        //var DurationSession = TimeSpan.FromHours(session.Film.Duration + timeoutInMin);
        //List<TimeOnly> allTimeStartSession = new List<TimeOnly>();
        //List<TimeOnly> allTimeEndSession = new List<TimeOnly>();

        //List<SessionBLL> AllSessionsInDate = _instanceMapperBll.MapListSessionDtoToListSessionBLL(_sessionRepository.GetAllSessionByDate(session.Date));

    }
}
