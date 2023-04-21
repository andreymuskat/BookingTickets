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
    }
}
