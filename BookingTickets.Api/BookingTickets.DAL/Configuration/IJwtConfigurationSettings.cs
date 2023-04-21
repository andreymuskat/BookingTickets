namespace BookingTickets.DAL.Configuration
{
    public interface IJwtConfigurationSettings
    {
        string Key { get; set; }

        int TokenTimeToLiveMinutes { get; set; }
    }
}
