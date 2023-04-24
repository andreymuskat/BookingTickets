namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public SeatDto CreateSeat(SeatDto seat);

        public List<SeatDto> GetAllFreeSeatsBySessionId(int idSession);

        public List<SeatDto> GetAllSeatInHall(int hallId);

        public List<SeatDto> GetAllPurchasedSeatsBySessionId(int idSession); 
    }
}
