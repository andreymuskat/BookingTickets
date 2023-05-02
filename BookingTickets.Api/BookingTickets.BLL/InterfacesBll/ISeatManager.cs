using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface ISeatManager
    {
        void AddRowToHall(AddSeatsRowsInputModel rowSeats);

        void CreateSeat(SeatBLL seat);

        List<SeatBLL> GetAllSeatsBySessionId(int sessionId);

        List<SeatBLL> GetFreeSeatsBySessionId(int sessionId);

        List<SeatsForCashierOutputModel> GetFreeSeatsBySessionIdForCashier(int sessionId);

        List<SeatBLL> GetPurchasedSeatsBySessionId(int sessionId);

        SeatBLL GetSeatById(int seatId);
    }
}