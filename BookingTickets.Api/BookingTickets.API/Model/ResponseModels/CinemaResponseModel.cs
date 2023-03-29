namespace BookingTickets.API.Model.ResponseModels
{
    public class CinemaResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<UserResponseModel> Employes { get; set; } = new();
    }
}
