using BookingTickets.BLL.Models.OutputModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class FilmManager
    {
        private readonly MapperBLL _mapper = new();
        private readonly IFilmRepository _repository;

        public FilmManager(IFilmRepository? repository = null)
        {
            //_repository = repository ?? new FilmRepository();
        }

        public List<FilmBLL> GetAllFilmByCinema(CinemaBLL cinema)
        {
            var res = _mapper.MapCinemaBLLToCinemaDto(cinema);

            return _mapper.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByCinema(res));
        }

        public List<FilmBLL> GetAllFilmByDay(DateTime dateTime)
        {
            return _mapper.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByDay(dateTime));
        }

        public List<FilmBLL> GetAllFilm()
        {
            return _mapper.MapListFilmDtoToListFilmBLL(_repository.GetAllFilm());
        }

        public void AddNewFilm(FilmBLL film)
        {
            _repository.AddNewFilm(_mapper.MapFilmBLLToFilmDto(film));
        }

        public void UpdateFilm(FilmBLL film)
        {
            _repository.UpdateFilm(_mapper.MapFilmBLLToFilmDto(film));
        }
    }
}
