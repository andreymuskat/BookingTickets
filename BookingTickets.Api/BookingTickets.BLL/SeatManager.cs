using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SeatManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISeatRepository _repository;

        public SeatManager(ISeatRepository repository)
        {
            _repository = repository;
        }

        public void CreateSeat(SeatBLL seat)
        {
            _repository.CreateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seat));
        }

        public void UpdateSeat(SeatBLL seat)
        {
            _repository.UpdateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seat));
        }

    }
}
