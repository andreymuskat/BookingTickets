using AutoMapper;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class MapperBLL
    {
        private readonly MapperConfiguration _configuration;
        private static MapperBLL _instanceMapperBll;

        private MapperBLL()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<FilmDto, FilmOutputModel>();
                    cfg.CreateMap<FilmOutputModel, FilmDto>();
                    cfg.CreateMap<FilmInputModel, FilmDto>();
                    cfg.CreateMap<CinemaInputModel, CinemaDto>();
                    cfg.CreateMap<HallDto, FullHallOutputModel>();
                    cfg.CreateMap<HallInputModel, HallDto>();                    
                    cfg.CreateMap<CinemaOutputModel, CinemaDto>();
                    cfg.CreateMap<SessionDto,SessionOutputModel>();
                    cfg.CreateMap<SessionInputModel, SessionDto>();
                    cfg.CreateMap<UserRegister, UserDto>();
                });
        }

        public static MapperBLL getInstance()
        {
            if (_instanceMapperBll is null)
            {
                _instanceMapperBll = new MapperBLL();
            }
            return _instanceMapperBll;
        }

        public List<FilmOutputModel> MapListFilmDtoToListFilmBLL(List<FilmDto> film)
        {
            return _configuration.CreateMapper().Map<List<FilmOutputModel>>(film);
        }

        public FilmOutputModel MapFilmDtoToFilmBLL(FilmDto film)
        {
            return _configuration.CreateMapper().Map<FilmOutputModel>(film);
        }

        public FilmDto MapFilmInputModelToFilmDto(FilmInputModel film)
        {
            return _configuration.CreateMapper().Map<FilmDto>(film);
        }

        public FilmDto MapFilmBLLToFilmDto(FilmOutputModel film)
        {
            return _configuration.CreateMapper().Map<FilmDto>(film);
        }

        public CinemaDto MapCinemaInputModelToCinemaDto(CinemaInputModel cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }

        public FullHallOutputModel MapHallDtoToFullHallOutputModel(HallDto hall)
        {
            return _configuration.CreateMapper().Map<FullHallOutputModel>(hall);
        }

        public HallDto MapHallInputModelToHallDto(HallInputModel hall)
        {
            return _configuration.CreateMapper().Map<HallDto>(hall);
        }

        public CinemaDto MapCinemaBLLToCinemaDto(CinemaOutputModel cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }
    }
}