using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SeatManager : ISeatManager
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public SeatManager(IMapper map, ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
            _mapper = map;
        }

        public void CreateSeat(SeatBLL seat)
        {
            _seatRepository.CreateSeat(_mapper.Map<SeatDto>(seat));
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

                _seatRepository.CreateSeat(_mapper.Map<SeatDto>(seatBll));
            }
        }

        public List<SeatBLL> GetFreeSeatsBySessionId(int sessionId)
        {
            return _mapper.Map<List<SeatBLL>>(_seatRepository.GetAllFreeSeatsBySessionId(sessionId));
        }

        public List<SeatsForCashierOutputModel> GetFreeSeatsBySessionIdForCashier(int sessionId)
        {
            return _mapper.Map<List<SeatsForCashierOutputModel>>(_seatRepository.GetAllFreeSeatsBySessionId(sessionId));
        }

        public List<SeatBLL> GetPurchasedSeatsBySessionId(int sessionId)
        {
            return _mapper.Map<List<SeatBLL>>(_seatRepository.GetAllPurchasedSeatsBySessionId(sessionId));
        }

        public List<SeatBLL> GetAllSeatsBySessionId(int sessionId)
        {
            return _mapper.Map<List<SeatBLL>>(_seatRepository.GetAllSeatsBySessionId(sessionId));
        }

        public SeatBLL GetSeatById(int seatId)
        {
            return _mapper.Map<SeatBLL>(_seatRepository.GetSeatById(seatId));
        }
    }
}
