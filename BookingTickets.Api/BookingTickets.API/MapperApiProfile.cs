using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_StatisticsRequestModels;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels;
using BookingTickets.API.Model.ResponseModels.All_UserResponseModels;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Hall_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.DAL.Models;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;

namespace BookingTickets.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<CreateAndUpdateFilmRequestModel, FilmBLL>();
            CreateMap<FilmBLL, CreateAndUpdateFilmRequestModel>();
            CreateMap<CreateAndUpdateCinemaRequestModel, CinemaBLL>();
            CreateMap<CreateSessionRequestModel, CreateSessionInputModel>();
            CreateMap<UserRequestModel, UserBLL>();
            CreateMap<UserBLL, UserResponseModel>();
            CreateMap<SessionRequestModel, SessionBLL>();
            CreateMap<AddSeatsRowsRequestModel, AddSeatsRowsInputModel>();
            CreateMap<SessionBLL, SessionResponseModel>();
            CreateMap<OrderForCashierResponseModel, OrderBLL>();
            CreateMap<OrderBLL, OrderRequestModel>();
            CreateMap<OrderBLL, OrderForCashierResponseModel>()
                .ForMember(src => src.NumberSeat, opt => opt.MapFrom(x => x.Seats.Number))
                .ForMember(src => src.NumberRow, opt => opt.MapFrom(x => x.Seats.Row))
                .ForMember(src => src.NumderHall, opt => opt.MapFrom(x => x.Session.Hall.Number))
                .ForMember(src => src.Date, opt => opt.MapFrom(x => x.Session.Date))
                .ForMember(src => src.FilmName, opt => opt.MapFrom(x => x.Session.Film.Name))
                .ForMember(src => src.CostSession, opt => opt.MapFrom(x => x.Session.Cost))
                .ForMember(src => src.Status, opt => opt.MapFrom(x => x.Status))
                .ForMember(src => src.Code, opt => opt.MapFrom(x => x.Code));
            CreateMap<OrderForCashierResponseModel, OrderBLL>();
            CreateMap<HallResponseModel, HallBLL>();
            CreateMap<SeatBLL, SeatResponseModel>();
            CreateMap<SeatResponseModel, SeatBLL>();
            CreateMap<CreateOrderRequestModel, CreateOrderInputModel>();
            CreateMap<CinemaBLL, CinemaResponseModel>();
            CreateMap<CreateCashierRequestModel, CreateCashierInputModel>();
            CreateMap<UserRegisterRequest, UserRegister>();
            CreateMap<AuthResult, AuthResponse>();
            CreateMap<AuthResponse, AuthResult>();
            CreateMap<UserRegister, UserDto>()
                .ForMember(src => src.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(src => src.Id, opt => opt.Ignore()); ;
            CreateMap<UserLoginRequest, UserLogin>();
            CreateMap<UserDto, UserBLL>();
            CreateMap<CreateNewEmployeeRequestModel, CreateNewEmployeeInputModel>();
            CreateMap<FilmBLL, FilmResponseModel>();
            CreateMap<FilmResponseModel, FilmBLL>();
            CreateMap<HallRequestModel, CreateAndUpdateHallInputModel>();
            CreateMap<SessionOutputModel, SessionResponseModel>();
            CreateMap<SessionBLL, SessionForCashierResponseModel>()
                .ForMember(src => src.Date, opt => opt.MapFrom(x => x.Date))
                .ForPath(src => src.Hall.Number, opt => opt.MapFrom(x => x.Hall.Number))
                .ForPath(src => src.Hall.Cinema.Name, opt => opt.MapFrom(x => x.Hall.Cinema.Name))
                .ForPath(src => src.Hall.Cinema.Address, opt => opt.MapFrom(x => x.Hall.Cinema.Address))
                .ForPath(src => src.Film.Duration, opt => opt.MapFrom(x => x.Film.Duration))
                .ForPath(src => src.Film.Name, opt => opt.MapFrom(x => x.Film.Name))
                .ForMember(src => src.Cost, opt => opt.MapFrom(x => x.Cost));
            CreateMap<SeatsForCashierOutputModel, SeatResponseModel>()
                .ForMember(src => src.NumderHall, opt => opt.MapFrom(x => x.Hall.Number));
            CreateMap<StatisticsFilm_ResquestModels, StatisticsFilm_InputModels>();
            CreateMap<StatisticsFilm_OutputModels, StatisticsFilm_ResponseModels>();
            CreateMap<UpdateCashierRequestModel, UpdateCashierInputModel>();
            CreateMap<StatisticDays_RequestModel, StatisticDays_InputModel>();
            CreateMap<StatisticDays_OutputModel, StatisticDays_ResponseModel>();
            CreateMap<StatisticCashiers_OutputModel, StatisticCashiers_ResponseModel>();
            CreateMap<StatisticCashiers_RequestModel, StatisticCashiers_InputModel>();
        }
    }
}
