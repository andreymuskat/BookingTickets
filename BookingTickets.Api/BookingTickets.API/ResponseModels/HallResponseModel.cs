namespace BookingTickets.API.Controllers.OutputModels
{
    public class HallResponseModel
	{
		public int Id { get; set; }
		public int CinemaId { get; set; }
		public int Number { get; set; }
		public bool IsDeleted { get; set; }
	}
}
