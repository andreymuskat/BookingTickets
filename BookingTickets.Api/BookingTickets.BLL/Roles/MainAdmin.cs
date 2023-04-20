using BookingTickets.BLL;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.NewFolder;

namespace BookingTickets.BLL.Roles
{
    public class MainAdmin : IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly FilmManager _filmManager;
        private readonly CinemaManager _cinemaManager;
        private readonly SeatManager _seatManager;
        private readonly HallManager _hallManager;

        public MainAdmin()
        {
            _filmManager = new FilmManager();
            _cinemaManager = new CinemaManager();
            _seatManager = new SeatManager();
            _hallManager = new HallManager();
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            _filmManager.CreateNewFilm(newFilm);
        }

        public void CreateCinema(CinemaBLL newCinema)
        {
            _cinemaManager.CreateCinema(newCinema);
        }
        public void CreateHall(HallBLL hall)
        {
            _hallManager.CreateHall(hall);
        }
    }                                                                
}