using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using BookingTickets.DAL.Models;

public class SessionDto
{
	[Key]
	public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [ForeignKey(nameof(FilmId))]
    public FilmDto Film { get; set; }

    public int FilmId { get; set; }

    [Required]
    [ForeignKey(nameof(HallId))]
    public HallDto Hall { get; set; }

    public int HallId { get; set; }

    [Required]
	public int Cost { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
