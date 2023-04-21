using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class FilmManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IFilmRepository _filmRepository;

        public FilmManager()
        {
            _filmRepository = new FilmRepository();
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            var filmDto = _instanceMapperBll.MapFilmBLLToFilmDto(newFilm);

            _filmRepository.CreateFilm(filmDto);
        }

        public List<FilmBLL> GetAllFilmByCinema(CinemaBLL cinema)
        {
            var res = _instanceMapperBll.MapCinemaBLLToCinemaDto(cinema);

            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_filmRepository.GetAllFilmByCinema(res));
        }

        public List<FilmBLL> GetAllFilmByDay(DateTime dateTime)
        {
            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_filmRepository.GetAllFilmByDay(dateTime));
        }

        public List<FilmBLL> GetAllFilm()
        {
            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_filmRepository.GetAllFilm());
        }

        public void AddNewFilm(FilmBLL film)
        {
            _filmRepository.AddNewFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        }

        public void UpdateFilm(FilmBLL film)
        {
            _filmRepository.UpdateFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        }

        public FilmBLL GetFilmById(int Id)
        {
            return _instanceMapperBll.MapFilmDtoToFilmBLL(_filmRepository.GetFilmById(Id));
        }
    }
}
