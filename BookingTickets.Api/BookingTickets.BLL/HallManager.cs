using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Hall_OutputModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class HallManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IHallRepository _hallRepository;
        private readonly ICinemaRepository _cinemaRepository;
        public HallManager()
        {
            _hallRepository = new HallRepository();
            _cinemaRepository = new CinemaRepository();
        }

        public void CreateHall(CreateHallInputModel hall)
        {
            _hallRepository.CreateHall(_instanceMapperBll.MapCreateHallInputModelToHallDto(hall));
        }

        public void DeleteHall(int hallId)
        {
            _hallRepository.DeleteHall(hallId);
        }
    }
}
