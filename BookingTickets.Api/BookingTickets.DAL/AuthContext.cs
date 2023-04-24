using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class AuthContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=localhost;Database=Booking;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<UserDto> Users { get; private set; }

        
    }
}
