using BookingTickets.Core.CustomException;
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

        public void CreateHall(CreateAndUpdateHallInputModel hall)
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

        public void EditHall(CreateAndUpdateHallInputModel newHall, int hallId)
        {
            var searchHall = _hallRepository.GetHallById(hallId);

            if (searchHall != null)
            {
                if (newHall.Number != null)
                {
                    searchHall.Number = newHall.Number;
                }

                if (newHall.CinemaId != null)
                {
                    searchHall.CinemaId = newHall.CinemaId;
                }

                _hallRepository.EditHall(searchHall);
            }
            else { throw new CinemaException(777); }
        }
    }
}
