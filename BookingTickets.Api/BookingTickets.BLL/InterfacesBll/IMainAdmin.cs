using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Hall_OutputModels;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void CreateNewFilm(FilmBLL newFilm);

        public void CreateCinema(CinemaBLL newCinema);

        public void DeleteCinema(int cinemaId);

        public void CreateHall(CreateHallInputModel hall);

        public void DeleteHall(int hallId);

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats);

        public void ChangeUserStatus(ChangeUserStatusInputModel newUser);
    }
}
