using AutoMapper;
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
                    cfg.CreateMap<FilmDto, FilmBLL>();
                    cfg.CreateMap<FilmBLL, FilmDto>();
                    cfg.CreateMap<CinemaInputModel, CinemaDto>();
                    cfg.CreateMap<HallDto, FullHallOutputModel>();
                    cfg.CreateMap<HallInputModel, HallDto>();                    
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<SessionDto,SessionOutputModel>();
                    cfg.CreateMap<SessionInputModel, SessionDto>();
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

        public List<FilmBLL> MapListFilmDtoToListFilmBLL(List<FilmDto> film)
        {
            return _configuration.CreateMapper().Map<List<FilmBLL>>(film);
        }

        public FilmBLL MapFilmDtoToFilmBLL(FilmDto film)
        {
            return _configuration.CreateMapper().Map<FilmBLL>(film);
        }

        public FilmDto MapFilmBLLToFilmDto(FilmBLL film)
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

        public CinemaDto MapCinemaBLLToCinemaDto(CinemaBLL cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }
    }
}