namespace BookingTickets.API.Controllers.OutputModels
{
    public class CinemaOutputModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public bool? IsDeleted { get; set; }
		public List<UserOutputModel> Employes { get; set; } = new();
	}
}
