using BookingTickets.BLL;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL;
using System.Collections;

FilmRepository fi = new FilmRepository();
SessionRepository ses =new SessionRepository();

DateTime date = new DateTime(2023, 05, 04);

ses.DeleteSession(2);
var ss = ses.GetAllSessionByDate(date);

Console.WriteLine(date);