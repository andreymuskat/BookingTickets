namespace BookingTickets.API.Controllers.InputModels
{
    public class CinemaInputModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public bool? IsDeleted { get; set; }
		public List<UserInputModel> Employes { get; set; } = new();
	}
}
