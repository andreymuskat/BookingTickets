using BookingTickets.DAL;

SeatRepository ss = new SeatRepository();

var pk = ss.GetAllFreeSeats(2);

Console.WriteLine("");