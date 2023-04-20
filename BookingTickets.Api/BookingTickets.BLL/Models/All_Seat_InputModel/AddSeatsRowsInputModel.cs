using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.BLL.Models.All_Seat_InputModel
{
    public class AddSeatsRowsInputModel
    {
        public int SeatForBegin { get; set; }
        public int SeatForEnd { get; set; }
        public int NumberOfRow { get; set; }
        public int HallId { get; set; }
    }
}
