﻿using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Models.InputModels
{
    public class SessionInputModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public int HallId { get; set; }
        public int FilmId { get; set; }
        public int Cost { get; set; }
        public bool IsDeleted { get; set; }
        public FilmDto FilmDto { get; set; }
        public HallDto HallDto { get; set; }
    }
}