namespace BookingTickets.API.Model.RequestModels
{
    public class HallRequestModel
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int Number { get; set; }
        public bool IsDeleted { get; set; }
    }
}
