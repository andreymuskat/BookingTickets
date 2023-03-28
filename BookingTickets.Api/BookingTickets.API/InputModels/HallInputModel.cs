namespace BookingTickets.API.Controllers.InputModels
{
    public class HallInputModel
	{
		public int Id { get; set; }
		public int CinemaId { get; set; }
		public int Number { get; set; }
		public bool IsDeleted { get; set; }
	}
}
