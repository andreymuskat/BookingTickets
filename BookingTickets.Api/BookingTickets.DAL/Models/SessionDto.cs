using System;
using System.ComponentModel.DataAnnotations;
using BookingTickets.DAL.Models;

public class SessionDto
{
	[Key]
	public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime TimeStart { get; set; }

    [Required]
    public int HallId { get; set; }

    [Required]
    public int FilmId { get; set; }

	[Required]
	public int Cost { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

    public FilmDto FilmDto { get; set; }

    public HallDto HallDto { get; set; }
}
