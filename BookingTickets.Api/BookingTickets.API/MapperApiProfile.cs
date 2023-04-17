using AutoMapper;
using BookingTickets.API.Model.RequestModels.CinemaRequestModel;
using BookingTickets.API.Model.RequestModels.FilmRequestModel;
using BookingTickets.API.Model.RequestModels.SessionRequestModel;
using BookingTickets.API.Model.ResponseModels;
using BookingTickets.BLL.Models;

namespace BookingTickets.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<CreateFilmRequestModel, FilmBLL>();
            CreateMap<FilmBLL, CreateFilmRequestModel>();
            CreateMap<CreateCinemaRequestModel, CinemaBLL>();
            CreateMap<CreateSessionRequestModel,SessionBLL>();
        }
    }
}
