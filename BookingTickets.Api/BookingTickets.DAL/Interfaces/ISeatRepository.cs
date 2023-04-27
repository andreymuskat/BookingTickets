namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public SeatDto CreateSeat(SeatDto seat);

        public List<SeatDto> GetAllSeatsBySessionId(int sessionId);

        public List<SeatDto> GetAllFreeSeatsBySessionId(int idSession);

        public SeatDto GetSeatById(int seatId);


        public List<SeatDto> GetAllSeatInHall(int hallId);

        public List<SeatDto> GetAllPurchasedSeatsBySessionId(int idSession); 
    }
}
