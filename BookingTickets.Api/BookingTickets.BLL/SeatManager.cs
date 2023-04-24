using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SeatManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISeatRepository _repository;

        public SeatManager()
        {
            _repository = new SeatRepository();
        }

        public void CreateSeat(SeatBLL seat)
        {
            _repository.CreateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seat));
        }

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats)
        {
            var seatForBegin = rowSeats.SeatForBegin;
            var SeatForEnd = rowSeats.SeatForEnd;
            var numberOfRow = rowSeats.NumberOfRow;
            var hallId = rowSeats.HallId;

            for (var i = seatForBegin; i <= SeatForEnd; i++)
            {
                SeatBLL seatBll = new SeatBLL()
                {
                    Number = i,
                    Row = numberOfRow,
                    HallId = hallId
                };

                _repository.CreateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seatBll));
            }
        }
        public List<SeatBLL> GetAllFreeSeatsBySessionId(int idSession)
        {
            return _instanceMapperBll.MapListSeatDtoToListSeatBLL(_repository.GetAllFreeSeatsBySessionId(idSession));
                
        }
    }
}
