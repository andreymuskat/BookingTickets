using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;

namespace BookingTickets.BLL
{
    public class HallManager : IHallManager
    {
        private readonly IHallRepository _hallRepository;
        private readonly IMapper _mapper;
        private readonly INLogLogger _logger;

        public HallManager(IMapper map, IHallRepository hallRepository, INLogLogger logger)
        {
            _hallRepository = hallRepository;
            _mapper = map;
            _logger = logger;
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
                _logger.Warn("Object with given number already exists");

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
                _logger.Warn("Object with given ID not found in database");

                throw new CinemaException(777);
            }
        }
    }
}
