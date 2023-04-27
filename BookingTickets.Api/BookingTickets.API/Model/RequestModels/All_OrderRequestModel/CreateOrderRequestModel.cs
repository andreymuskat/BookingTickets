using Core;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.API.Model.RequestModels.All_OrderRequestModel
{
    public class CreateOrderRequestModel
    {
        public int SeatsId { get; set; }

        public int SessionId { get; set; }
    }
}

