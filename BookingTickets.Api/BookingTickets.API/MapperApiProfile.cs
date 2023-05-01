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
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.DAL.Models;
using CompanyName.Application.WebApi.OrdersApi.Models.Auth.Responses;
using BookingTickets.BLL.Models.All_User_InputModel;
using BookingTickets.API.Model.RequestModels.All_StatisticRequestModels;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.API.Model.ResponseModels.All_StatisticResponseModels;
using System.Collections.Generic;

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
            CreateMap<UpdateCashierRequestModel, UpdateCashierInputModel>();
            CreateMap<StatisticOfDaysByMonthAndYearRequestModel,StatisticOfDaysByMonthAndYearInputModel>();
            CreateMap<StatisticOfDaysByMonthAndYearInputModel,StatisticOfDaysByMonthAndYearResponseModel>();
            CreateMap<UserResponseModel,UserBLL>();
            CreateMap<UserBLL,UserResponseModel>();
        }
    }
}
