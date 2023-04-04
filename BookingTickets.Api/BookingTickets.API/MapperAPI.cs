using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL.Models.OutputModels;

namespace BookingTickets.API
{
    public class MapperAPI
    {
        private readonly MapperConfiguration _configuration;

        public MapperAPI()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<FilmBLL, FilmResponseModel>();
                    cfg.CreateMap<CinemaRequestModel, CinemaBLL>();
                });
        }

        public List<FilmResponseModel> MapListFilmBLLToListFilmResponseModel(List<FilmBLL> film)
        {
            return _configuration.CreateMapper().Map<List<FilmResponseModel>>(film);
        }

        public CinemaBLL MapCinemaRequestModelToCinemaBLL(CinemaRequestModel model)
        {
            return _configuration.CreateMapper().Map<CinemaBLL>(model);
        }
    }
}
