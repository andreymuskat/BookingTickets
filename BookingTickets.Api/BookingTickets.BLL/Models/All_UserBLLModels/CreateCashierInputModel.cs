﻿namespace BookingTickets.BLL.Models.All_UserBLLModels
{
    public class CreateCashierInputModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int CinemaId { get; set; }
    }
}