using BookingTickets.DAL;
using System.Collections;

SessionRepository SessionRepository= new SessionRepository();


var ss  = SessionRepository.GetAllSessionByCinemaId(1);

Console.WriteLine(ss);