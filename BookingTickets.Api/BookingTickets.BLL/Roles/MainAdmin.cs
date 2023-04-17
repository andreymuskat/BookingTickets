using BookingTickets.BLL.Models;
using BookingTickets.BLL.NewFolder;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL.Roles
{
    public class MainAdmin : IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly FilmManager _filmManager;
        private readonly CinemaManager _cinemaManager;

        public MainAdmin(FilmManager filmManager, CinemaManager cinemaManager)
        {
            _filmManager = filmManager;
            _cinemaManager = cinemaManager;
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            _filmManager.CreateNewFilm(newFilm);
        }

        public void CreateCinema(CinemaBLL newCinema)
        {
            _cinemaManager.CreateCinema(newCinema);
        }
    }
}
