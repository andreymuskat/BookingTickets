namespace BookingTickets.API.Model.RequestModels.CinemaRequestModel
{
    public class CinemaRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsDeleted { get; set; }
    }
}