using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class AuthContext : IdentityDbContext
    {
        private readonly IAuthRepositorySettings settings;

        public DbSet<UserDto> Users { get; private set; }

        public AuthContext(IAuthRepositorySettings repositorySettings) : base()
        {
            settings = repositorySettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (settings.IsInMemory)
            {
                builder.UseInMemoryDatabase(settings.DatabaseName);
            }
            else
            {
                builder.UseSqlServer(settings.ConnectionString);
            }
        }
    }
}
