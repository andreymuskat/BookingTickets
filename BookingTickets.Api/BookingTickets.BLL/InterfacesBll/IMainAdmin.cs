using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void CreateNewFilm(FilmBLL newFilm);

        public void CreateCinema(CinemaBLL newCinema);
        public void CreateHall(HallBLL hall);
    }
}
