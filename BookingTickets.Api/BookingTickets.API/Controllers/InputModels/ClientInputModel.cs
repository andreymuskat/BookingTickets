namespace BookingTickets.API.Controllers.InputModels
{
    public class ClientInputModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
