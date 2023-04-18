using BookingTickets.DAL.Configuration;

namespace BookingTickets.API.Options
{
    public class JwtConfigurationSettings : IJwtConfigurationSettings
    {
        public string Key { get; set; } = null!;

        public int TokenTimeToLiveMinutes { get; set; }

    }
}
