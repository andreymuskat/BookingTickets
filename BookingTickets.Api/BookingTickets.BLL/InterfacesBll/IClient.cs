﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IClient
    {
        public FilmBLL GetFilmByName(string name);   
        
        public List<SessionBLL> GetFilmsByCinema(FilmBLL film, CinemaBLL cinema);

        public List<CinemaBLL> GetCinemaByFilm(FilmBLL film);

        public List<SessionBLL> GetSessionsByFilm(FilmBLL film);

        public List<SeatBLL> GetFreeSeatsBySession(SessionBLL session);
    }
}
