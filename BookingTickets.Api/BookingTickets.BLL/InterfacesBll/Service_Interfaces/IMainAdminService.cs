using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll.Service_Interfaces
{
    public interface IMainAdminService
    {
        void AddRowToHall(AddSeatsRowsInputModel rowSeats);
        void ChangeUserStatus(UserStatus status, int userId);
        void CreateCinema(CinemaBLL newCinema);
        void CreateHall(CreateAndUpdateHallInputModel hall);
        void CreateNewFilm(FilmBLL newFilm);
        void DeleteCinema(int cinemaId);
        void DeleteFilm(int filmId);
        void DeleteHall(int hallId);
        void EditCinema(CinemaBLL newCinema, int cinemaId);
        void EditFilm(FilmBLL newFilm, int idFilm);
        void EditHall(CreateAndUpdateHallInputModel newHall, int hallId);
        StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic);
    }
}