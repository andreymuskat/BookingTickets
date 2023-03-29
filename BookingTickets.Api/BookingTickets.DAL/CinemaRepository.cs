using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class CinemaRepository : ICinemaRepository
    {
        public int CreateCinema(CinemaDto cinema)
        {
            return cinema.Id;
        }

        public void UpdateCinema(CinemaDto cinema)
        {

        }

        public void DeleteCinema(int idCinema)
        {

        }

        public void AddNewEmployesInCinema(UserDto user)
        {

        }

        public void DeleteEmployesInCinema(int userId)
        {

        }

        public List<UserDto> GetAllEmployesInCinema(int idCinema)
        {
            return new List<UserDto>();
        }

        public List<HallDto> GetAllHallByCinemaId(int idCinema)
        {
            return new List<HallDto>();
        }
    }
}
