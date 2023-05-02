﻿using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ICinemaRepository
    {
        public CinemaDto CreateCinema(CinemaDto cinema);

        public void DeleteCinemaById(int cinemaId);

        public List<CinemaDto> GetAllCinema();

        public CinemaDto GetCinemaById(int cinemaId);

        public List<CinemaDto> GetAllCinemaByFilm(int idFilm);

        public CinemaDto GetCinemaByHallId(int hallId);

        public void EditCinema(CinemaDto cinema);
    }
}
