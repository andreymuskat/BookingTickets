using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SeatManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISeatRepository _seatRepository;

        public SeatManager()
        {
            _seatRepository = new SeatRepository();
        }

        public void CreateSeat(SeatBLL seat)
        {
            _seatRepository.CreateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seat));
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

                _seatRepository.CreateSeat(_instanceMapperBll.MapSeatBLLToSeatDto(seatBll));
            }
        }

        public List<SeatBLL> GetFreeSeatsBySessionId(int sessionId)
        {
            return _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllFreeSeatsBySessionId(sessionId));
        }

        public List<SeatBLL> GetPurchasedSeatsBySessionId(int sessionId)
        {
            return _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllPurchasedSeatsBySessionId(sessionId));
        }

        public List<SeatBLL> GetAllSeatsBySessionId(int sessionId)
        {
            return _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllSeatsBySessionId(sessionId));
        }
    }
}