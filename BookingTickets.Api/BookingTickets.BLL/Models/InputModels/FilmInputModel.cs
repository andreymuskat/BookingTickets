using System.ComponentModel.DataAnnotations;

namespace BookingTickets.BLL.Models.InputModels
{
    public class FilmInputModel
    {
        public string Name { get; set; }

        public int Duration { get; set; }
    }
}
