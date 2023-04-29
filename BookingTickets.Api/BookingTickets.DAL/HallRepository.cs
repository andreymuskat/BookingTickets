using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class HallRepository : IHallRepository
    {
        private static Context context;
        private SeatRepository seatRepository;
        public HallRepository()
        {
            context = new Context();
        }
        public HallDto CreateHall(HallDto hall)
        {
            HallDto hallDto = new HallDto
            {
                Number = hall.Number
            };

            context.SaveChanges();

            return new HallDto                                          
            {
                Id = hall.Id,
                Number = hall.Number
            };
        }
    }
}
