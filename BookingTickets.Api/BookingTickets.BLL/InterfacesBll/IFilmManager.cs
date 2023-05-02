using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IFilmManager
    {
        void CreateNewFilm(FilmBLL newFilm);

        void DeleteFilm(int filmId);

        void EditFilm(FilmBLL newFilm, int filmId);

        FilmBLL GetFilmById(int Id);
    }
}