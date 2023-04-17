using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.API.Model.ResponseModels;
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
                    cfg.CreateMap<FilmRequestModel, FilmBLL>();
                    cfg.CreateMap<CinemaRequestModel, CinemaBLL>();
                    cfg.CreateMap<UserBLL, UserResponseModel>();
                });
        }

        public List<FilmResponseModel> MapListFilmBLLToListFilmResponseModel(List<FilmBLL> film)
        {
            return _configuration.CreateMapper().Map<List<FilmResponseModel>>(film);
        }
        
        public FilmBLL MapFilmRequestModelToFilmBLL(FilmRequestModel film)
        {
            return _configuration.CreateMapper().Map<FilmBLL>(film);
        }

        public CinemaBLL MapCinemaRequestModelToCinemaBLL(CinemaRequestModel model)
        {
            return _configuration.CreateMapper().Map<CinemaBLL>(model);
        }

        public UserResponseModel MapUserBLLToUserResponseModel(UserBLL userBLL)
        {
            return _configuration.CreateMapper().Map<UserResponseModel>(userBLL);
        }

        public UserBLL MapUserResponseModelToUserBLL(UserResponseModel user)
        {
            return _configuration.CreateMapper().Map<UserBLL>(user);
        }
    }
}
