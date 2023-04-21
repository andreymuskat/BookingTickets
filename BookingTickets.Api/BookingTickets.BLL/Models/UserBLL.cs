using Core;

namespace BookingTickets.BLL.Models
{
    public class UserBLL
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaBLL Cinema { get; set; }

        public int CinemaId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
