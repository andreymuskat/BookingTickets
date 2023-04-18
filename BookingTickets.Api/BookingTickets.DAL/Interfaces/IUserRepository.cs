﻿using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        int AddNewUser(UserDto user);
    }
}
