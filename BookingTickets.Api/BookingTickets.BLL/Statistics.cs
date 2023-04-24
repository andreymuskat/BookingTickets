using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class Statistics
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISeatRepository _seatRepository;

        public Statistics()
        {
            _orderRepository = new OrderRepository();
            _seatRepository = new SeatRepository();
        }

        public void GetStatisticFilmsInCinema(int cinemaId)
        {
            //List<SeatDto> allSeats _seatRepository.GetAllFreeSeats(cinemaId);
        }
    }
}
