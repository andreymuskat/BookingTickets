using AutoMapper;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Hall_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
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
                    cfg.CreateMap<HallBLL, HallDto>();
                    cfg.CreateMap<HallDto, HallBLL>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<CinemaDto, CinemaBLL>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                    cfg.CreateMap<SessionDto, SessionBLL>()
                        .ForMember(src => src.Film, opt => opt.MapFrom(x => x.Film))
                        .ForMember(src => src.Hall, opt => opt.MapFrom(x => x.Hall))
                        .ForPath(src => src.Hall.Cinema, opt => opt.MapFrom(x => x.Hall.Cinema));
                    cfg.CreateMap<SessionBLL, SessionDto>()
                        .ForMember(src => src.Film, opt => opt.MapFrom(x => x.Film))
                        .ForMember(src => src.Hall, opt => opt.MapFrom(x => x.Hall))
                        .ForPath(src => src.Hall.Cinema, opt => opt.MapFrom(x => x.Hall.Cinema));
                    cfg.CreateMap<HallDto, HallBLL>();
                    cfg.CreateMap<HallBLL, HallDto>();
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
                    cfg.CreateMap<UpdateCashierInputModel, UserDto>()
                    .ForMember(src => src.CinemaId, opt => opt.MapFrom(x => x.CinemaId));
                    cfg.CreateMap<CreateNewEmployeeInputModel, UserDto>()
                        .ForMember(src => src.CinemaId, opt => opt.MapFrom(x => x.CinemaId))
                        .ForMember(src => src.CinemaId, opt => opt.MapFrom(x => x.Password))
                        .ForMember(src => src.UserName, opt => opt.MapFrom(x => x.Name));
                    cfg.CreateMap<OrderDto, OrderBLL>();
                    cfg.CreateMap<OrderBLL, OrderDto>();
                    cfg.CreateMap<CreateOrderInputModel, OrderDto>();
                    cfg.CreateMap<OrderDto, CreateOrderInputModel>();
                    cfg.CreateMap<SessionDto, SessionOutputModel>()
                        .ForMember(src => src.FilmId, opt => opt.MapFrom(x => x.FilmId))
                        .ForMember(src => src.HallId, opt => opt.MapFrom(x => x.HallId));
                    cfg.CreateMap<SessionOutputModel, SessionDto>()
                        .ForMember(src => src.FilmId, opt => opt.MapFrom(x => x.FilmId))
                        .ForMember(src => src.HallId, opt => opt.MapFrom(x => x.HallId));
                    cfg.CreateMap<SeatDto, SeatsForCashierOutputModel>()
                        .ForMember(src => src.Hall, opt => opt.MapFrom(x => x.Hall));
                    cfg.CreateMap<CreateAndUpdateHallInputModel, HallDto>();
                    cfg.CreateMap<HallDto, HallOutputModel>();
                    .ForMember(src => src.CinemaId, opt => opt.MapFrom(x => x.CinemaId))
                    .ForMember(src => src.CinemaId, opt => opt.MapFrom(x => x.Password))
                    .ForMember(src => src.UserName, opt => opt.MapFrom(x => x.Name));
                    cfg.CreateMap<SessionDto, CreateSessionInputModel>();
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

        public CinemaBLL MapCinemaDtoToCinemaBLL(CinemaDto cinema)
        {
            return _configuration.CreateMapper().Map<CinemaBLL>(cinema);
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

        public List <SeatBLL> MapListSeatDtoToListSeatBLL(List <SeatDto> seat)
        {
            return _configuration.CreateMapper().Map<List<SeatBLL>>(seat);
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

        public SessionDto MapCreateSessionInputModelToSessionDto(CreateSessionInputModel session)
        {
            return _configuration.CreateMapper().Map<SessionDto>(session);
        }

        public OrderDto MapCreateOrderInputModelToOrderDto(CreateOrderInputModel session)
        {
            return _configuration.CreateMapper().Map<OrderDto>(session);
        }

        public List <OrderDto> MapCreateListOrderInputModelToListOrderDto (List <CreateOrderInputModel> session)
        {
            return _configuration.CreateMapper().Map<List<OrderDto>>(session);
        }

        public List<OrderBLL> MapCreateListOrderDtoModelToListOrderBll(List<OrderDto> session)
        {
            return _configuration.CreateMapper().Map<List<OrderBLL>>(session);
        }
        public List<CinemaBLL> MapListCinemaDtoToListCinemaBLL(List<CinemaDto> cinema)
        {
            return _configuration.CreateMapper().Map<List<CinemaBLL>>(cinema);
        }

        public SessionBLL MapSessionDtoToSessionBLL(SessionDto session)
        {
            return _configuration.CreateMapper().Map<SessionBLL>(session);
        }
        public OrderBLL MapOrderDtoToOrderBll (OrderDto order)
        {
            return _configuration.CreateMapper().Map<OrderBLL>(order);
        }

        public OrderDto MapOrderBLLToOrderDto (OrderBLL order)
        {
            return _configuration.CreateMapper().Map<OrderDto>(order);
        }

        public List<UserBLL> MapListUserDtoToListUserBLL(List<UserDto> users)
        {
            return _configuration.CreateMapper().Map<List<UserBLL>>(users);
        }

        public UserDto MapCreateCashierInputModelToUserDto(CreateCashierInputModel user)
        {
            return _configuration.CreateMapper().Map<UserDto>(user);
        }

        public UserDto MapUpdateCashierInputModelToUserDto(UpdateCashierInputModel user)
        {
            return _configuration.CreateMapper().Map<UserDto>(user);
        }

        public UserDto MapCreateNewEmployeeInputModelToUserDto(CreateNewEmployeeInputModel userEmploy)
        {
            return _configuration.CreateMapper().Map<UserDto>(userEmploy);
        }

        public SessionOutputModel MapSessionDtoToSessionOutputModels(SessionDto session)
        {
            return _configuration.CreateMapper().Map<SessionOutputModel>(session);
        }

        public HallDto MapCreateHallInputModelToHallDto(CreateAndUpdateHallInputModel hall)
        {
            return _configuration.CreateMapper().Map<HallDto>(hall);
        }

        public HallOutputModel MapHallDtoToHallOutputModel(HallDto hall)
        {
            return _configuration.CreateMapper().Map<HallOutputModel>(hall);
        }

        public List<SeatsForCashierOutputModel> MapListSeatDtoToListSeatsForCashierOutputModel(List<SeatDto> seats)
        {
            return _configuration.CreateMapper().Map<List<SeatsForCashierOutputModel>>(seats);
        }

        public List<SessionBLL> MapListSessionDtoToListSessionBLL(List<SessionDto> sessionBLL)
        {
            return _configuration.CreateMapper().Map<List<SessionBLL>>(sessionBLL);
        }

        public List<CreateSessionInputModel> MapListSessionsDtoToListCreateSessionInputModel(List <SessionDto> sessions)
        {
            return _configuration.CreateMapper().Map< List<CreateSessionInputModel>>(sessions);
        }
    }
}