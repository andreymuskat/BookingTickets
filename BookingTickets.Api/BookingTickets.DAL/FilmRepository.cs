﻿using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class FilmRepository
    {
        public List<FilmDto> GetAllFilmByCinema(CinemaDto cinema)
        { 
            return  new List<FilmDto>();
        }

        public List<FilmDto> GetAllFilmByDay(DateTime dateTime)
        {
            return new List<FilmDto>();
        }

        public List<FilmDto> GetAllFilm()
        {
            return new List<FilmDto>();
        }

        public void AddNewFilm(FilmDto film)
        {

        }

        public void UpdateFilm(FilmDto film)
        {

        }
    }
}