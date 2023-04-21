namespace BookingTickets.API.Model.ResponseModels
{
    public class HallResponseModelForClient : HallResponseModel
    {
        public CinemaResponseModel Cinema { get; set; }
    }
}
