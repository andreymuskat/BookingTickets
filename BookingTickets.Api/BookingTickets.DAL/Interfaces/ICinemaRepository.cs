using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ICinemaRepository
    {
        public int CreateCinema(CinemaDto cinema);

        public void UpdateCinema(CinemaDto cinema);

        public void DeleteCinema(int idCinema);

        public void AddNewEmployesInCinema(UserDto user);

        public void DeleteEmployesInCinema(int userId);

        public List<UserDto> GetAllEmployesInCinema(int idCinema);

        public List<HallDto> GetAllHallByCinemaId(int idCinema);
    }
}
