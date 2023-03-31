using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.API
{
    public class FilmApi
    {
        private readonly MapperAPI _mapper = new();       
        private readonly FilmManager _filmManager;

        public FilmApi(FilmManager? filmManager = null)
        {
            _filmManager = filmManager ?? new FilmManager();
        }
        public List<FilmResponseModel> GetAllFilmByCinema(CinemaRequestModel cinema)
        {
            var res = _mapper.MapCinemaRequestModelToCinemaBLL(cinema);
            
            return _mapper.MapListFilmBLLToListFilmResponseModel(_filmManager.GetAllFilmByCinema(res));
        }
    }
}
