using System;
using System.ComponentModel.DataAnnotations;

public class FilmDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public bool IsDeleted { get; set; } 
}