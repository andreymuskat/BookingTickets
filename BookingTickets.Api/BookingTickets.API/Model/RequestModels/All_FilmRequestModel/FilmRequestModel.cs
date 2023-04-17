namespace BookingTickets.API.Model.RequestModels.All_FilmRequestModel
{
    public class FilmRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public bool IsDeleted { get; set; }
    }
}