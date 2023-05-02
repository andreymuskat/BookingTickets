using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IFilmRepository
    {
        FilmDto CreateFilm(FilmDto film);

        FilmDto GetFilmById(int filmId);

        FilmDto GetFilmByName(string Name);

        void DeleteFilm(int filmId);

        void EditFilm(FilmDto film);
    }
}
