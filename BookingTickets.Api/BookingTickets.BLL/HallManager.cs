using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
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
            var checkHall = _hallRepository.GetHallByNumber(hall.Number);

            if (checkHall == null)
            {
                _hallRepository.CreateHall(_instanceMapperBll.MapCreateHallInputModelToHallDto(hall));
            }
            else { throw new HallException(105); }

        }

        public void DeleteHall(int hallId)
        {
            _hallRepository.DeleteHall(hallId);
        }
    }
}
