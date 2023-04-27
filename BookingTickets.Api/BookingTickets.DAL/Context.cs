using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class Context : IdentityDbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=194.87.210.5;Initial Catalog = BookingTickets; Persist Security Info=True;TrustServerCertificate=True; User ID = student;Password=qwe!23;");
        }

        public DbSet<HallDto> Halls { get; set; }
        public DbSet<FilmDto> Films { get; set; }
        public DbSet<CinemaDto> Cinemas { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<SeatDto> Seats { get; set; }
        public DbSet<SessionDto> Sessions { get; set; }
        public DbSet<UserDto> Users { get; set; }
    }
}
