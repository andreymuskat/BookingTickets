﻿namespace BookingTickets.API.Model.ResponseModels.All_FilmResponseModels
{
    public class FilmResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Duration { get; set; }

        public bool IsDeleted { get; set; }
    }
}