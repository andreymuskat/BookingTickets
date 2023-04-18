using BookingTickets.DAL.Configuration;

namespace BookingTickets.API.Options
{
    public class AuthRepositorySettings : IAuthRepositorySettings
    {
        public string ConnectionString { get; set; }

        public bool IsInMemory { get; set; }

        public string DatabaseName { get; set; }
    }
}
