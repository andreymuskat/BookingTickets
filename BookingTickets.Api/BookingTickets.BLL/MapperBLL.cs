using AutoMapper;
using BookingTickets.BLL.Models;
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
                    cfg.CreateMap<FilmBLL, FilmDto>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<HallDto, HallBLL>();
                    cfg.CreateMap<HallBLL, HallDto>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<SessionDto, SessionBLL>();
                    cfg.CreateMap<SessionBLL, SessionDto>();
                    cfg.CreateMap<UserDto, UserBLL>();
                    cfg.CreateMap<UserBLL, UserDto>();
                    cfg.CreateMap<SeatBLL, SeatDto>();
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

        public CinemaDto MapCinemaBLLToCinemaDto(CinemaBLL cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }

        public HallBLL MapHallDtoToFullHallBLL(HallDto hall)
        {
            return _configuration.CreateMapper().Map<HallBLL>(hall);
        }

        public HallDto MapHallBLLModelToHallDto(HallBLL hall)
        {
            return _configuration.CreateMapper().Map<HallDto>(hall);
        }

        public SeatDto MapSeatBLLToSeatDto(SeatBLL seat)
        {
            return _configuration.CreateMapper().Map<SeatDto>(seat);
        }


        public SessionDto MapSessionBLLToSessionDto(SessionBLL session)
        {
            return _configuration.CreateMapper().Map<SessionDto>(session);
        }

        public UserBLL MapUserDtoUserBLL(UserDto user)
        {
            return _configuration.CreateMapper().Map<UserBLL>(user);
        }

        public UserDto MapUserBLLUserDto(UserBLL user)
        {
            return _configuration.CreateMapper().Map<UserDto>(user);
        }

        public List<SessionBLL> MapListSessionDtoToListSessionBLL(List<SessionDto> session)
        {
            return _configuration.CreateMapper().Map<List<SessionBLL>>(session);
        }
    }
}