namespace BookingTickets.BLL.InterfacesBll
{
    public interface IStatisticsFilm
    {
        int AmountTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd);

        decimal BoxOfficeOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd);

        int NotPurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd);

        int PurchasedTicketsOnFilmInCinema(int cinemaId, int filmId, DateOnly dateStart, DateOnly dateEnd);
    }
}