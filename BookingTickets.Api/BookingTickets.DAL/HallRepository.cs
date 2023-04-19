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
                Number = hall.Number
            };

            context.SaveChanges();

            return new HallDto
            {
                Id = hall.Id,
                Number = hall.Number
            };
        }

        public void AddRowToHall(int idHall, int seatForBegin, int seatForEnd, int numberOfRow)
        { 


            for (int i= seatForBegin; i<= seatForEnd; i++ )
            {
                
            }

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
