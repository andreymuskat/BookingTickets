using AutoMapper;
using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.Authentication.AuthModels;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_Seat_InputModel;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.DAL.Models;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;

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
            CreateMap<UserRegisterRequest, UserRegister>();
            CreateMap<AuthResult, AuthResponse>();
            CreateMap<AuthResponse, AuthResult>();
            CreateMap<UserRegister, UserDto>()
                .ForMember(src => src.Name, opt => opt.MapFrom(x => x.UserName))
                .ForMember(src => src.Id, opt => opt.Ignore()); ;
            CreateMap<UserLoginRequest, UserLogin>();
            CreateMap<UserDto, UserBLL>();
        }
    }
}
