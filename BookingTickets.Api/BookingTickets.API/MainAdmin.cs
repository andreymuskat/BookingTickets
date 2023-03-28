using BookingTickets.API.Controllers.OutputModels;

namespace BookingTickets.API
{
    public class MainAdmin
    {
        public string Name { get; set; }

        public List<CinemaOutputModel> GetAllCinemaByMovie(MovieInputModel cinema)
        {
            var result = new List<CinemaOutputModel>();
            return result;
        }
    }
}
