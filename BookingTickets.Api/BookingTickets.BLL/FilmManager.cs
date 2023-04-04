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
            _repository = repository ?? new FilmRepository();
        }
        public List<FilmBLL> GetAllFilmByCinema(CinemaBLL cinema)
        {
            var res = _mapper.MapCinemaBLLToCinemaDto(cinema);

            return _mapper.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByCinema(res));
        }
    }
}
