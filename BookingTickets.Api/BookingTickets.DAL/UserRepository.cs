﻿using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext context;


        public int AddNewUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
