using BookingTickets.BLL.Statistics;

Statistics_Film stat = new Statistics_Film();

DateOnly start = new DateOnly(2023, 01, 20);
DateOnly end = new DateOnly(2024, 01, 20);

int a = stat.NotPurchasedTicketsOnFilmInCinema(7, 5, start, end);
int b = stat.PurchasedTicketsOnFilmInCinema(7, 5, start, end);
int c = stat.AmountTicketsOnFilmInCinema(7, 5, start, end);


Console.WriteLine("");