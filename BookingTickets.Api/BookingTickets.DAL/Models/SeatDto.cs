using BookingTickets.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SeatDto
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int Number { get; set; }

	[Required]
	public int Row { get; set; }

    [Required]
    [ForeignKey(nameof(HallId))]
    public HallDto Hall { get; set; }

	public int HallId { get; set; }
}