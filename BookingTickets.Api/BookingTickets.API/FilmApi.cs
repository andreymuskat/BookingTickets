using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL;

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
        public List<FilmResponseModel> GetAllFilmByDay(DateTime dateTime)
        {
            return _mapper.MapListFilmBLLToListFilmResponseModel(_filmManager.GetAllFilmByDay(dateTime));
        }

        public List<FilmResponseModel> GetAllFilm()
        {
            return _mapper.MapListFilmBLLToListFilmResponseModel(_filmManager.GetAllFilm());    
        }

        public void AddNewFilm(FilmRequestModel film)
        {
            _filmManager.AddNewFilm(_mapper.MapFilmRequestModelToFilmBLL(film));
        }

        public void UpdateFilm(FilmRequestModel film)
        {
            _filmManager.UpdateFilm(_mapper.MapFilmRequestModelToFilmBLL(film));
        }
    }
}
