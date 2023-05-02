using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels
{
    public class StatisticsFilm_ResquestModels
    {
        [FromHeader]
        public string DataStart { get; set; }

        [FromHeader]
        public string DataEnd { get; set; }

        [FromHeader]
        public int FilmId { get; set; }
    }
}
