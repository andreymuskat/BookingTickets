using BookingTickets.BLL.Models;
using BookingTickets.BLL.NewFolder;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class MainAdmin : IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private IFilmRepository _filmRepository;

        public MainAdmin(IFilmRepository repository)
        {
            _filmRepository = repository;
        }

        public void AddNewFilm(FilmBLL newFilm)
        {
            var filmDto = _instanceMapperBll.MapFilmInputModelToFilmDto(newFilm);
            var filmByName = _filmRepository.GetFilmByName(filmDto.Name);
            if (filmByName == null)
            {
                _filmRepository.CreateFilm(filmDto);
            }
            else
            {
                throw new Exception("Такой фильм уже есть в базе!");
            }
        }

        public FilmBLL GetFilmByName(string name)
        {
            var res = _filmRepository.GetFilmByName(name);

            return _instanceMapperBll.MapFilmDtoToFilmBLL(res);
        }
    }
}
