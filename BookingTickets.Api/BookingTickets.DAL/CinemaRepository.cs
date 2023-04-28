using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly Context _context;

        public CinemaRepository()
        {
            _context = new Context();
        }

        public CinemaDto CreateCinema(CinemaDto cinema)
        {
            _context.Cinemas.Add(cinema);

            _context.SaveChanges();

            return cinema;
        }

        public CinemaDto GetCinemaById(int cinemaId)
        {
            return _context.Cinemas
                .SingleOrDefault(i => i.Id == cinemaId)!;
        }

        public List<CinemaDto> GetAllCinemaByFilm(int idFilm)
        {
            var x = _context.Sessions.Include(h => h.Hall).ThenInclude(c => c.Cinema).Where(f => f.FilmId == idFilm).ToList();
            List<CinemaDto> cinemaDtos = new List<CinemaDto>();

            foreach (var cinema in x)
            {
                cinemaDtos.Add(cinema.Hall.Cinema);
            }

            return cinemaDtos;
        }

        public CinemaDto GetCinemaByHallId(int hallId)
        {
            var cinemaId = _context.Halls.SingleOrDefault(k => k.Id == hallId).CinemaId;

            var cinemaDto = GetCinemaById(cinemaId);

            return cinemaDto;
        }
    }
}
