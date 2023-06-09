﻿using System.ComponentModel.DataAnnotations;

namespace BookingTickets.DAL.Models
{
    public class CinemaDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
