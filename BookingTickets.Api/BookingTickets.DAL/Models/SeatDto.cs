using System;
using System.ComponentModel.DataAnnotations;

public class SeatDto
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int Number { get; set; }

	[Required]
	public int Row { get; set; }
}
