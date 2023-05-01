using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_FilmRequestModel;

public class CreateAndUpdateFilmRequestModel
{
    [FromHeader]
    public string Name { get; set; }

    [FromHeader]
    public int Duration { get; set; }
}
