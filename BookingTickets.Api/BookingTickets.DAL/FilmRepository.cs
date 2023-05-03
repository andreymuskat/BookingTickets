using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;

namespace BookingTickets.DAL
{
    public class FilmRepository : IFilmRepository
    {
        private readonly Context _context;
        private readonly INLogLogger _logger;

        public FilmRepository(INLogLogger logger)
        {
            _context = new Context();
            _logger = logger;
        }

        public FilmDto CreateFilm(FilmDto film)
        {
            _context.Films.Add(film);

            _context.SaveChanges();

            _logger.Info($"FilmID:{film.Id}, FilmName: {film.Name} create and written to the database.");

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

            _logger.Info($"FilmID:{filmId}, delete(change IsDelete) the database.");
        }

        public void EditFilm(FilmDto film)
        {
            var filmDb = _context.Films
                .Where(k => k.IsDeleted == false)
                .Single(k => k.Id == film.Id);

            filmDb.Name = film.Name;
            filmDb.Duration = film.Duration;

            _context.SaveChanges();

            _logger.Info($"FilmID:{film.Id}, edit and written to the database. New Name - {filmDb.Name}, Duration - {filmDb.Duration}");
        }
    }
}
