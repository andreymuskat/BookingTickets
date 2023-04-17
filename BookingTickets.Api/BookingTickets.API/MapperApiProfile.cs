using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.Models;

namespace BookingTickets.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<FilmRequestModel, FilmBLL>();
            CreateMap<FilmResponseModel, FilmBLL>();
            CreateMap<FilmBLL, FilmResponseModel>();
            CreateMap<UserRequestModel, UserBLL>();
            CreateMap<UserBLL, UserResponseModel>();
        }
    }
}
