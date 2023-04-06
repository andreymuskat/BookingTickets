using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly Context _context;

        public CinemaRepository(Context context)
        {
            _context = context;
        }

        public CinemaDto CreateCinema(CinemaDto cinema)
        {
            _context.Cinemas.Add(cinema);

            _context.SaveChanges();

            return cinema;
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
