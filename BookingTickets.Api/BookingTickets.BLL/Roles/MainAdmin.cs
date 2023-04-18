﻿using BookingTickets.BLL;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.NewFolder;

namespace BookingTickets.BLL.Roles
{
    public class MainAdmin : IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly FilmManager _filmManager;
        private readonly CinemaManager _cinemaManager;

        public MainAdmin()
        {
            _filmManager = new FilmManager();
            _cinemaManager = new CinemaManager();
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            _filmManager.CreateNewFilm(newFilm);
        }

        public void CreateCinema(CinemaBLL newCinema)
        {
            _cinemaManager.CreateCinema(newCinema);
        }
    }
}