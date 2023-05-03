using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_SessionRequestModel
{
    public class CopySessionsRequestModel
    {
        [FromHeader]
        public DateTime DateCopy { get; set; }

        [FromHeader]
        public DateTime DateWhereToCopy { get; set; }
    }
}
