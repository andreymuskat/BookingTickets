﻿using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        int AddNewUser(UserDto user);

        UserDto CreateNewCashier(UserDto user);

        void DeleteCashierById(int idCashier);

        List<UserDto> GetAllCashiers();

        List<UserDto> GetAllUsers();

        UserDto GetUserById(int idUser);

        void UpdateUserStatus(UserDto user);

        void UpdateUserCinemaId(UserDto user);

        UserDto GetCashierById(int idCashier);

        List<UserDto> GetAllCashiersByCinemaId(int cinemaId);

        UserDto UpdateCashier(UserDto user);
    }
}