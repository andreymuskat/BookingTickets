using BookingTickets.DAL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.DAL
{
    public class FilmRepository : IFilmRepository
    {
        private readonly Context _context;

        public FilmRepository(Context context)
        {
            _context = context;
        }

        public FilmDto CreateFilm (FilmDto film)
        {
            _context.Films.Add(film);

            _context.SaveChanges();

            return film;
        }

        public List<FilmDto> GetAllFilmByCinema(CinemaDto cinema)
        { 
            return  new List<FilmDto>
            { 
                new FilmDto
            {
                Id = 1,
                Name="Jackass"
            },
                new FilmDto
            {
                Id = 2,
                Name="Alien"
            },
            };
        }

        public List<FilmDto> GetAllFilmByDay(DateTime dateTime)
        {
            return new List<FilmDto>();
        }

        public List<FilmDto> GetAllFilm()
        {
            return new List<FilmDto>();
        }

        public FilmDto GetFilmByName(string name)
        {
            return _context.Films
                .Single(k => k.Name == name);
        }

        public void AddNewFilm(FilmDto film)
        {

        }

        public void UpdateFilm(FilmDto film)
        {

        }
    }
}
