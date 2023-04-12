using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IFilmRepository
    {
        public List<FilmDto> GetAllFilmByCinema(CinemaDto cinema);
        public FilmDto CreateFilm(FilmDto film);
        public List<FilmDto> GetAllFilmByDay(DateTime dateTime);
        public List<FilmDto> GetAllFilm();
        public FilmDto GetFilmByName(string name);
        public void AddNewFilm(FilmDto film);
        public void UpdateFilm(FilmDto film);
    }
}
