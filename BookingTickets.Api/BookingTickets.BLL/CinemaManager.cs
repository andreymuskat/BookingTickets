using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;

namespace BookingTickets.BLL
{
    public class CinemaManager : ICinemaManager
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly INLogLogger _logger;
        private readonly IMapper _mapper;

        public CinemaManager(IMapper map, INLogLogger logger, ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
            _mapper = map;
            _logger = logger;
        }

        public void CreateCinema(CinemaBLL cinema)
        {
            _cinemaRepository.CreateCinema(_mapper.Map<CinemaDto>(cinema));
        }

        public void EditCinema(CinemaBLL cinema, int cinemaId)
        {
            var searchCinema = _cinemaRepository.GetCinemaById(cinemaId);

            if (searchCinema != null)
            {
                if (cinema.Name != null)
                {
                    searchCinema.Name = cinema.Name;
                }

                if (cinema.Address != null)
                {
                    searchCinema.Address = cinema.Address;
                }

                _cinemaRepository.EditCinema(searchCinema);
            }
            else
            {
                throw new CinemaException(777);
            }
        }

        public void DeleteCinema(int cinemaId)
        {
            _cinemaRepository.DeleteCinemaById(cinemaId);
        }

        public List<CinemaBLL> GetCinemaByFilm(int idFilm)
        {
            var listCinemas = _mapper.Map<List<CinemaBLL>>(_cinemaRepository.GetAllCinemaByFilm(idFilm));

            if (listCinemas != null)
            {
                return listCinemas;
            }
            else 
            { 
                throw new CinemaException(777);
            }
        }

        public CinemaBLL GetCinemaBySessionId(int sessionId)
        {
            var searchCinema = _cinemaRepository.GetCinemaBySessionId(sessionId);

            if (searchCinema != null)
            {
                return _mapper.Map<CinemaBLL>(searchCinema);
            }
            else
            {
                _logger.Warn("Object not found in database.");

                throw new CinemaException(777);
            }
        }

        public CinemaBLL GetCinemaByHallId(int idHallId)
        {
            var searchCinema = _cinemaRepository.GetCinemaByHallId(idHallId);

            if (searchCinema != null)
            {
                return _mapper.Map<CinemaBLL>(searchCinema);
            }
            else
            {
                _logger.Warn("Object not found in database.");

                throw new CinemaException(777);
            }
        }

        public List<CinemaBLL> GetAllCinema()
        {
            return _mapper.Map<List<CinemaBLL>>(_cinemaRepository.GetAllCinema());
        }
    }
}               
