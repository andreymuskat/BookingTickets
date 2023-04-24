using BookingTickets.BLL.Statistics;

Statistics_Film stat = new Statistics_Film();

int a = stat.PercentNotPurchasedTicketsOnFilm(5, 1);

int b = stat.PercentPurchasedTicketsOnFilm(5, 1);

Console.WriteLine("");