﻿using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class CinemaManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaManager()
        {
            _cinemaRepository = new CinemaRepository();
        }

        public void CreateCinema(CinemaBLL cinema)
        {
            _cinemaRepository.CreateCinema(_instanceMapperBll.MapCinemaBLLToCinemaDto(cinema));
        }

        public void DeleteCinema(int cinemaId)
        {
            _cinemaRepository.DeleteCinemaById(cinemaId);
        }

        public List<CinemaBLL> GetCinemaByFilm(int idFilm)
        {
            var listCinemas = _instanceMapperBll.MapListCinemaDtoToListCinemaBLL(_cinemaRepository.GetAllCinemaByFilm(idFilm));
            if (listCinemas != null)
            {
                return listCinemas;
            }
            else { throw new CinemaException(777); }
        }

        public CinemaBLL GetCinemaByHallId(int idHallId)
        {
            return _instanceMapperBll.MapCinemaDtoToCinemaBLL(_cinemaRepository.GetCinemaByHallId(idHallId));
        }
    }
}
