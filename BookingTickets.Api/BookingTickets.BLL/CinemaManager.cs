using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class CinemaManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ICinemaRepository _repository;

        public CinemaManager()
        {
            _repository = new CinemaRepository();
        }

        public void CreateCinema(CinemaBLL cinema)
        {
            _repository.CreateCinema(_instanceMapperBll.MapCinemaBLLToCinemaDto(cinema));
        }
    }
}
