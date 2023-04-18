namespace BookingTickets.BLL.Models
{
    public class HallBLL
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public CinemaBLL Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}
