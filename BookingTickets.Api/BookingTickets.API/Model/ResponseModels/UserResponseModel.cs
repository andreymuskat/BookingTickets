﻿using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Model.ResponseModels
{
    public class UserResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaResponseModel Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}