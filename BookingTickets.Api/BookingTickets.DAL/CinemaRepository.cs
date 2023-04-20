using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly Context _context;

        public CinemaRepository()
        {
            _context = new Context();
        }

        public CinemaDto CreateCinema(CinemaDto cinema)
        {
            _context.Cinemas.Add(cinema);

            _context.SaveChanges();

            return cinema;
        }

        public List<UserDto> GetAllEmployesInCinema(int idCinema)
        {
            return new List<UserDto>();
        }

        public List<HallDto> GetAllHallByCinemaId(int idCinema)
        {
            return new List<HallDto>();
        }

        public List<CinemaDto> GetAllCinemaByFilm(int idFilm)
        {
            return new List<CinemaDto>();
        }
    }
}
