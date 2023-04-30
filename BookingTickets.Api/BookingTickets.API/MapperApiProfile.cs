using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.DAL.Models;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;
using BookingTickets.BLL.Models.All_User_InputModel;
using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SessionResponseModels;
using BookingTickets.API.Model.ResponseModels.All_UserResponseModels;
using BookingTickets.API.Model.ResponseModels.All_OrderResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;
using BookingTickets.API.Model.ResponseModels.All_SeatResponseModels;
using BookingTickets.BLL.Models.All_OrderBLLModel;

namespace BookingTickets.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<CreateFilmRequestModel, FilmBLL>();
            CreateMap<FilmBLL, CreateFilmRequestModel>();
            CreateMap<CreateCinemaRequestModel, CinemaBLL>();
            CreateMap<CreateSessionRequestModel, CreateSessionInputModel>();
            CreateMap<UserRequestModel, UserBLL>();
            CreateMap<UserBLL, UserResponseModel>();
            CreateMap<SessionRequestModel, SessionBLL>();
            CreateMap<AddSeatsRowsRequestModel, AddSeatsRowsInputModel>();
            CreateMap<SessionBLL, SessionResponseModelForClient>();
            CreateMap<OrderForCashierResponseModel, OrderBLL > ();
            CreateMap<OrderBLL, OrderRequestModel>();
            CreateMap<OrderBLL, OrderForCashierResponseModel>()
                .ForMember(src => src.NumberSeat, opt => opt.MapFrom(x => x.Seats.Number))
                .ForMember(src => src.NumberRow, opt => opt.MapFrom(x => x.Seats.Row))
                .ForMember(src => src.NumderHall, opt => opt.MapFrom(x => x.Session.Hall.Number))
                .ForMember(src => src.Date, opt => opt.MapFrom(x => x.Session.Date))
                .ForMember(src => src.FilmName, opt => opt.MapFrom(x => x.Session.Film.Name))
                .ForMember(src => src.CostSession, opt => opt.MapFrom(x => x.Session.Cost))
                .ForMember(src => src.Status, opt => opt.MapFrom(x => x.Status));
            CreateMap<OrderForCashierResponseModel, OrderBLL>();
            CreateMap<HallBLL, HallResponseModelForClient> ();
            CreateMap<HallResponseModel, HallBLL>();
            CreateMap<SeatBLL, SeatResponseModel>();
            CreateMap<SeatResponseModel, SeatBLL>();
            CreateMap<CreateOrderRequestModel, CreateOrderInputModel>();
            CreateMap<CinemaBLL, CinemaResponseModel>();
            CreateMap<UserBLL, UserResponseModel>();
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
            CreateMap<FilmBLL, FilmResponseModelForClient>();
            CreateMap<FilmResponseModelForClient, FilmBLL>();
            CreateMap<ChangeUserStatusInputModel, ChangeUserStatusRequesModel>();
            CreateMap<ChangeUserStatusRequesModel, ChangeUserStatusInputModel>();
            CreateMap<SessionOutputModel, SessionResponseModelForClient>();
            CreateMap<SessionBLL, SessionForCashierResponseModel>()
                .ForMember(src => src.Date, opt => opt.MapFrom(x => x.Date))
                .ForMember(src => src.NameFilm, opt => opt.MapFrom(x => x.Film.Name))
                .ForMember(src => src.Duration, opt => opt.MapFrom(x => x.Film.Duration))
                .ForMember(src => src.NumberHall, opt => opt.MapFrom(x => x.Hall.Number))
                .ForMember(src => src.Cost, opt => opt.MapFrom(x => x.Cost));
            CreateMap<SeatsForCashierOutputModel, SeatResponseModel>()
                .ForMember(src => src.NumderHall, opt => opt.MapFrom(x => x.Hall.Number));
        }
    }
}
