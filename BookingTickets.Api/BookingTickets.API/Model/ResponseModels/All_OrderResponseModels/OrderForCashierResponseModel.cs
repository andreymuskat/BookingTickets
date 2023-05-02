using Core;
﻿using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_OrderResponseModels
{
    public class OrderForCashierResponseModel
    {
        public int NumberSeat { get; set; }

        public int NumberRow { get; set; }

        public int NumderHall { get; set; }

        public DateTime Date { get; set; }

        public string FilmName { get; set; }

        public int CostSession { get; set; }

        public string Status { get; set; }
    }
}
