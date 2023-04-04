using System;
using System.ComponentModel.DataAnnotations;

public class FilmDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime Duration { get; set; }

    [Required]
    public bool IsDeleted { get; set; } 

}