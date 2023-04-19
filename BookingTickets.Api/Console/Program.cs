using BookingTickets.BLL;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL;
using System.Collections;

FilmRepository fi = new FilmRepository();
SessionRepository ses =new SessionRepository();

DateTime date = new DateTime(2023, 05, 01);

var ss = ses.GetAllSessionByDate(date);

Console.WriteLine(ss);