using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;

namespace BookingTickets.BLL.NewFolder
{
    public interface IMainAdmin
    {
        public void CreateNewFilm(FilmBLL newFilm);

        public void CreateCinema(CinemaBLL newCinema);
        public void CreateHall(HallBLL hall);

        public void AddRowToHall(AddSeatsRowsInputModel rowSeats);
    }
}
