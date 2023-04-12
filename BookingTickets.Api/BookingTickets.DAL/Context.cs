using Microsoft.EntityFrameworkCore;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=userappdb;Trusted_Connection=True;");

            builder.UseSqlServer(@"Server=localhost;Database=CinemaOrders;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        //builder.UseInMemoryDatabase("BookingTicketsDb");

        public DbSet<HallDto> Halls { get; set; }

        public DbSet<FilmDto> Films { get; set; }

        public DbSet<CinemaDto> Cinemas { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<SeatDto> Seats { get; set; }
        public DbSet<SessionDto> Sessions { get; set; }
        public DbSet<UserDto> Users { get; set; }
    }
}
