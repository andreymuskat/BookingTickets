using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingTickets.DAL.Configuration;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class AuthContext : IdentityDbContext
    {
        private readonly IAuthRepositorySettings settings;

        public DbSet<UserDal> Users { get; private set; }

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
