﻿using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class HallManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IHallRepository _repository;

        public HallManager(IHallRepository repository)
        {
            _repository = repository;
        }

        public void CreateHall(HallBLL hall)
        {
            _repository.CreateHall(_instanceMapperBll.MapHallBLLModelToHallDto(hall));
        }

        public void AddRowToHall(int idHall, int seatForBegin, int seatForEnd, int numberOfRow)
        {
            _repository.AddRowToHall( idHall,  seatForBegin,  seatForEnd,  numberOfRow);
        }
    }
}
