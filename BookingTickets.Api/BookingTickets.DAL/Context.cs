using Microsoft.EntityFrameworkCore;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseSqlServer(sqlConectionString)
            builder.UseInMemoryDatabase("BookingTicketsDb");
        }

        public DbSet<HallDto> Hall { get; set; }
    }
}
