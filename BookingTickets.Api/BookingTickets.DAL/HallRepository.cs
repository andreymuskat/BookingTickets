using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class HallRepository : IHallRepository
    {
        private static Context context;

        public HallRepository()
        {
            context = new Context();
        }
        public HallDto CreateHall(HallDto hall)
        {
            HallDto hallDto = new HallDto
            {
                Number = hall.Number,
                Seats = hall.Seats
            };

            context.Add(hallDto);

            context.SaveChanges();

            return new HallDto
            {
                Id = hall.Id,
                Number = hall.Number,
                Seats = hall.Seats
            };
        }

        public void UpdateHall(HallDto hall)
        {

        }

        public void DeleteHall(int idHall)
        {

        }

        public List<SeatDto> GetAllSeatsByHallId(int idHall)
        {
            return new List<SeatDto>();
        }
    }
}
