using System;

public class SessionOutputModel
{
	public int Id { get; set; }
	public DateTime Date { get; set; }
	public DateTime TimeStart { get; set; }
	public int HallId { get; set; }
	public int FilmId { get; set; }
	public int Cost { get; set; }
	public bool IsDeleted { get; set; }
}
