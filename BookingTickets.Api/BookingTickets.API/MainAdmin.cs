using BookingTickets.API.Model.ResponseModels;

namespace BookingTickets.API
{
    public class MainAdmin
    {
        public string Name { get; set; }

        public List<CinemaResponseModel> GetAllCinemaByMovie(FilmRequestModel cinema)
        {
            var result = new List<CinemaResponseModel>();
            return result;
        }
    }
}
