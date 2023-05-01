using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class FilmRepository : IFilmRepository
    {
        private readonly Context _context;

        public FilmRepository()
        {
            _context = new Context();
        }

        public FilmDto CreateFilm(FilmDto film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();

            return film;
        }

        public FilmDto GetFilmById(int filmId)
        {
            return _context.Films
                .Where(k => k.IsDeleted == false)
                .SingleOrDefault(k => k.Id == filmId)!;
        }

        public FilmDto GetFilmByName(string Name)
        {
            return _context.Films
                .Where(k => k.IsDeleted == false)
                .SingleOrDefault(k => k.Name == Name)!;
        }

        public void DeleteFilm(int filmId)
        {
            _context.Films.Single(k => k.Id == filmId).IsDeleted = true;

            _context.SaveChanges();
        }

        public void EditFilm(FilmDto film)
        {
            var filmDb = _context.Films
                .Where(k => k.IsDeleted == false)
                .Single(k => k.Id == film.Id);

            filmDb.Name = film.Name;
            filmDb.Duration = film.Duration;

            _context.SaveChanges();
        }
    }
}
