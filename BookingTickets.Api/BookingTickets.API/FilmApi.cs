using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.API
{
    public class FilmApi
    {
        private readonly MapperAPI _mapper = new();
        private readonly MapperBLL _map = new();
        private readonly IFilmRepository _repository;

        public FilmApi(IFilmRepository? repository = null)
        {
            _repository = repository ?? new FilmRepository();
        }
        public List<FilmResponseModel> GetAllFilmByCinema(CinemaRequestModel cinema)
        {
            var res = _map.MapCinemaBLLToCinemaDto(_mapper.MapCinemaRequestModelToCinemaBLL(cinema));
            
            return _mapper.MapListFilmBLLToListFilmResponseModel(
                _map.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByCinema(res)));
        }
    }
}
