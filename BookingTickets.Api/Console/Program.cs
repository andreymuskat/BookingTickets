using BookingTickets.BLL;
using BookingTickets.BLL.Statistics;

CinemaManager cin = new CinemaManager();

var pp = cin.GetCinemaByHallId(31);

Console.WriteLine(" ");