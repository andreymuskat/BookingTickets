using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.BLL.Models
{
    public class UserBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int? CinemaId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
