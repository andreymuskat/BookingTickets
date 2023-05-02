namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        SeatDto CreateSeat(SeatDto seat);

        SeatDto GetSeatById(int seatId);

        List<SeatDto> GetAllSeatInHall(int hallId);

        List<SeatDto> GetAllSeatsBySessionId(int sessionId);

        List<SeatDto> GetAllFreeSeatsBySessionId(int idSession);

        List<SeatDto> GetAllPurchasedSeatsBySessionId(int idSession);
    }
}
