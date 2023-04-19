using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections;

namespace BookingTickets.DAL
{
    public class SessionRepository: ISessionRepository
    {
        private readonly Context _context;

        public SessionRepository ()
        {
            _context = new Context();
        }
        public SessionDto CreateSession(SessionDto session)
        { 
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public List<SessionDto> GetAllSession()
        {
            return new List<SessionDto>();
        }

        public void UpdateSession(SessionDto session)
        {

        }

        public List<SessionDto> GetAllSessionByFilmId(int idFilm)
        {
            return new List<SessionDto>();
        }

        public List<SessionDto> GetAllSessionByCinemaId(int idCinema)
        {
            return _context.Sessions
                .Where(k => k.Hall.Cinema.Id == idCinema)
                .ToList();
        }

        public List<SessionDto> GetAllSessionByDate(DateTime Date)
        {
            DateOnly dateSearch = DateOnly.FromDateTime(Date);

            List <SessionDto> sessionInDay = _context.Sessions
                .Where(t => DateOnly.FromDateTime(t.Date) == dateSearch)
                .ToList();

            return sessionInDay;
        }

        public void DeleteSession(int idSession)
        {

        }
    }
}
