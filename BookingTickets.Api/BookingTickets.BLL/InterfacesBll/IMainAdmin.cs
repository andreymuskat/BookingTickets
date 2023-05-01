using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using Core;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void CreateNewFilm(FilmBLL newFilm);

        public void EditFilm(FilmBLL newFilm, int idFilm);

        public void DeleteFilm(int filmId);

        public void CreateCinema(CinemaBLL newCinema);

        public void EditCinema(CinemaBLL newCinema, int cinemaId);

        public void DeleteCinema(int cinemaId);

        public void CreateHall(CreateAndUpdateHallInputModel hall);

        public void DeleteHall(int hallId);

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats);

        public void ChangeUserStatus(UserStatus status, int userId);

        public void EditHall(CreateAndUpdateHallInputModel newHall, int hallId);
    }
}
