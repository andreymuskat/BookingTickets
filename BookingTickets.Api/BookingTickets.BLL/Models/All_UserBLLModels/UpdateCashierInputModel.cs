﻿namespace BookingTickets.BLL.Models.All_UserBLLModels
{
    public class UpdateCashierInputModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int CinemaId { get; set; }
    }
}