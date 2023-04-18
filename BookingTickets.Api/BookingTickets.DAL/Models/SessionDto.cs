﻿using System.ComponentModel.DataAnnotations;
using BookingTickets.DAL.Models;

public class SessionDto
{
	[Key]
	public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public FilmDto Film { get; set; }

    public HallDto Hall { get; set; }

    [Required]
	public int Cost { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
}
