namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class CreateNewEmployeeRequestModel
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int CinemaId { get; set; }
    }
}
