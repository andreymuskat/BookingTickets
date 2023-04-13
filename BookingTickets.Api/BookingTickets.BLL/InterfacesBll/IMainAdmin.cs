using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void AddNewFilm(FilmInputModel newFilm);

        public FilmOutputModel GetFilmByName(string name);
    }
}
