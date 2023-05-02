using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IFilmRepository
    {
        public FilmDto CreateFilm(FilmDto film);

        public FilmDto GetFilmById(int filmId);

        public FilmDto GetFilmByName(string Name);

        public void DeleteFilm(int filmId);

        public void EditFilm(FilmDto film);
    }
}
