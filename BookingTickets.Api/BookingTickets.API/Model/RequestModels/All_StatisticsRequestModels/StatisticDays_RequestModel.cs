using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_StatisticsRequestModels
{
    public class StatisticDays_RequestModel
    {
        [FromHeader]
        public DateTime DateStart { get; set; }

        [FromHeader]
        public DateTime DateEnd { get; set; }
    }
}
