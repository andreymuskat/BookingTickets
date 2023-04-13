using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class FilmManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IFilmRepository _repository;

        public FilmManager(IFilmRepository repository )
        {
            _repository = repository;
        }

        public List<FilmBLL> GetAllFilmByCinema(CinemaBLL cinema)
        {
            var res = _instanceMapperBll.MapCinemaBLLToCinemaDto(cinema);

            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByCinema(res));
        }

        public List<FilmBLL> GetAllFilmByDay(DateTime dateTime)
        {
            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByDay(dateTime));
        }

        public List<FilmBLL> GetAllFilm()
        {
            return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilm());
        }

        public void AddNewFilm(FilmBLL film)
        {
            _repository.AddNewFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        }

        public void UpdateFilm(FilmBLL film)
        {
            _repository.UpdateFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        }
    }
}
