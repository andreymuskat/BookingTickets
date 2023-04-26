using BookingTickets.BLL.Statistics;

Statistics_Film stat = new Statistics_Film();

DateOnly start = new DateOnly(2023, 01, 01);
DateOnly end = new DateOnly(2024, 01, 01);

int a = stat.NotPurchasedTicketsOnFilmInCinema(5, 1, start, end);
int b = stat.PurchasedTicketsOnFilmInCinema(5, 1, start, end);
int c = stat.AmountTicketsOnFilmInCinema(5, 1, start, end);


Console.WriteLine("");