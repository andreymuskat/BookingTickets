﻿using Core.Status;

namespace BookingTickets.BLL.Models
{
    public class UserBLL
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public UserStatus UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaBLL Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}