using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
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
        private readonly UserManager _userManager;

        public MainAdmin()
        {
            _filmManager = new FilmManager();
            _cinemaManager = new CinemaManager();
            _seatManager = new SeatManager();
            _hallManager = new HallManager();
            _userManager = new UserManager();
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            _filmManager.CreateNewFilm(newFilm);
        }

        public void CreateCinema(CinemaBLL newCinema)
        {
            _cinemaManager.CreateCinema(newCinema);
        }

        public void DeleteCinema(int cinemaId)
        {
            _cinemaManager.DeleteCinema(cinemaId);
        }

        public void CreateHall(CreateAndUpdateHallInputModel hall)
        {
            _hallManager.CreateHall(hall);
        }

        public void DeleteHall(int hallId)
        {
            _hallManager.DeleteHall(hallId);
        }

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats)
        {
            _seatManager.AddRowToHall(rowSeats);
        }

        public void ChangeUserStatus(ChangeUserStatusInputModel newUser)
        {
            _userManager.ChangeUserStatus(newUser);
        }

        public void DeleteFilm(int filmId)
        {
            _filmManager.DeleteFilm(filmId);
        }

        public void EditFilm(FilmBLL newFilm, int idFilm)
        {
            _filmManager.EditFilm(newFilm, idFilm);
        }

        public void EditCinema(CinemaBLL newCinema, int cinemaId)
        {
            _cinemaManager.EditCinema(newCinema, cinemaId);
        }

        public void EditHall(CreateAndUpdateHallInputModel newHall, int hallId)
        {
            _hallManager.EditHall(newHall, hallId);
        }
    }
}