using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class CinemaManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ICinemaRepository _repository;

        public CinemaManager(ICinemaRepository repository)
        {
            _repository = repository;
        }

        public void CreateCinema(CinemaBLL cinema)
        {
            _repository.CreateCinema(_instanceMapperBll.MapCinemaBLLToCinemaDto(cinema));
        }
    }
}
