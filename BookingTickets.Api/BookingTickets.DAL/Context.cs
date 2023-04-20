using Microsoft.EntityFrameworkCore;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=localhost;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<HallDto> Halls { get; set; }
        public DbSet<FilmDto> Films { get; set; }
        public DbSet<CinemaDto> Cinemas { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<SeatDto> Seat { get; set; }
        public DbSet<SessionDto> Sessions { get; set; }
        public DbSet<UserDto> Users { get; set; }
    }
}
