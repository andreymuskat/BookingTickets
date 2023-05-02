using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class HallManager : IHallManager
    {
        private readonly IHallRepository _hallRepository;
        private readonly IMapper _mapper;

        public HallManager(IMapper map, IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
            _mapper = map;
        }

        public void CreateHall(CreateAndUpdateHallInputModel hall)
        {
            var checkHall = _hallRepository.GetHallByNumber(hall.Number);

            if (checkHall == null)
            {
                _hallRepository.CreateHall(_mapper.Map<HallDto>(hall));
            }
            else
            {
                throw new HallException(105);
            }

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
            else
            {
                throw new CinemaException(777);
            }
        }
    }
}
