using AutoMapper;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_UserBLLModels;
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
                    cfg.CreateMap<HallDto, HallBLL>();
                    cfg.CreateMap<HallBLL, HallDto>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<CinemaDto, CinemaBLL>();
                    cfg.CreateMap<SessionDto, SessionBLL>();
                    cfg.CreateMap<SessionBLL, SessionDto>();
                    cfg.CreateMap<UserDto, UserBLL>()
                    .ForMember(src => src.Cinema, opt => opt.MapFrom(x => x.Cinema));
                    cfg.CreateMap<CreateSessionInputModel, SessionDto>()
                    .ForMember(src => src.FilmId, opt => opt.MapFrom(x => x.FilmId))
                    .ForMember(src => src.HallId, opt => opt.MapFrom(x => x.HallId))
                    .ForMember(src => src.Date, opt => opt.MapFrom(x => x.Date))
                    .ForMember(src => src.Cost, opt => opt.MapFrom(x => x.Cost));
                    cfg.CreateMap<SeatBLL, SeatDto>();
                    cfg.CreateMap<SeatDto, SeatBLL>();
                    cfg.CreateMap<AddSeatsRowsInputModel, SeatDto>();
                    cfg.CreateMap<UserBLL, UserDto>()
                    .ForMember(src => src.Cinema, opt => opt.MapFrom(x => x.Cinema));
                    cfg.CreateMap<CreateCashierInputModel, UserDto>();
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

        public SeatDto MapSeatInputToSeatDto(AddSeatsRowsInputModel seat)
        {
            return _configuration.CreateMapper().Map<SeatDto>(seat);
        }

        public SeatBLL MapSeatDtoToSeatBLL(SeatDto seat)
        {
            return _configuration.CreateMapper().Map<SeatBLL>(seat);
        }

        public SessionDto MapSessionBLLToSessionDto(SessionBLL session)
        {
            return _configuration.CreateMapper().Map<SessionDto>(session);
        }

        public UserBLL MapUserDtoToUserBLL(UserDto user)
        {
            return _configuration.CreateMapper().Map<UserBLL>(user);
        }

        public UserDto MapUserBLLToUserDto(UserBLL user)
        {
            return _configuration.CreateMapper().Map<UserDto>(user);
        }

        public List<SessionBLL> MapListSessionDtoToListSessionBLL(List<SessionDto> session)
        {
            return _configuration.CreateMapper().Map<List<SessionBLL>>(session);
        }

        public SessionDto MapCreateSessionInputModelToSessionDto(CreateSessionInputModel session)
        {
            return _configuration.CreateMapper().Map<SessionDto>(session);
        }

        public List<CinemaBLL> MapListCinemaDtoToListCinemaBLL(List<CinemaDto> cinema)
        {
            return _configuration.CreateMapper().Map<List<CinemaBLL>>(cinema);
        }

        public SessionBLL MapSessionDtoToSessionBLL(SessionDto session)
        {
            return _configuration.CreateMapper().Map<SessionBLL>(session);
        }

        public List<UserBLL> MapListUserDtoToListUserBLL(List<UserDto> users)
        {
            return _configuration.CreateMapper().Map<List<UserBLL>>(users);
        }
        
        public UserDto MapCreateCashierInputModelToUserDto(CreateCashierInputModel user)
        {
            return _configuration.CreateMapper().Map<UserDto>(user);
        }
    }
}