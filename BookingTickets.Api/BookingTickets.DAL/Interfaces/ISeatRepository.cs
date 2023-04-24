namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public SeatDto CreateSeat(SeatDto seat);

        public void UpdateSeat(SeatDto seat);

        public List<SeatDto> GetFreeSeatsBySessionInHisCinema(SessionDto session);
    }
}
