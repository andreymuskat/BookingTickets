using BookingTickets.BLL;
using BookingTickets.BLL.Statistics;

SessionManager cin = new SessionManager();

var pp = cin.GetAllSessionByCinemaId(7);

Console.WriteLine(" ");