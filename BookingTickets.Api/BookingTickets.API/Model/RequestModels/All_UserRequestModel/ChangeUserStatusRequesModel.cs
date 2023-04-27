namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class ChangeUserStatusRequesModel
    {
        public int userId { get; set; }

        public int newUserStatus { get; set; }
    }
}
