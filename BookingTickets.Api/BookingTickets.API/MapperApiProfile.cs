using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.RequestModels.All_OrderRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.DAL.Models;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;
using BookingTickets.BLL.Models.All_User_InputModel;

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
            CreateMap<OrderResponseModel, OrderBLL>();
            CreateMap<OrderBLL, OrderRequestModel>();
            CreateMap<HallBLL, HallResponseModelForClient>();
            CreateMap<HallResponseModel, HallBLL>();
            CreateMap<SeatBLL, SeatRequestModel>();
            CreateMap<SeatResponseModel, SeatBLL>();
            CreateMap<CreateOrderRequestModel,CreateSessionInputModel>();

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
        }
    }
}
