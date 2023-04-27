using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class Context : IdentityDbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Environment.GetEnvironmentVariable("BookingTickets"));
        }

        public DbSet<HallDto> Halls { get; set; }
        public DbSet<FilmDto> Films { get; set; }
        public DbSet<CinemaDto> Cinemas { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<SeatDto> Seats { get; set; }
        public DbSet<SessionDto> Sessions { get; set; }
        public DbSet<UserDto> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var fkey in builder.Model.GetEntityTypes().SelectMany(k => k.GetForeignKeys()))
            {
                fkey.DeleteBehavior = DeleteBehavior.NoAction;    
            }

        }
    }
}
