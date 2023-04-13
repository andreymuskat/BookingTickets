using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void AddNewFilm(FilmBLL newFilm);

        public FilmBLL GetFilmByName(string name);
    }
}
