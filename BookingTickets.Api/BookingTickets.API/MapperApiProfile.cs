using AutoMapper;
using BookingTickets.API.Model.RequestModels;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;

namespace BookingTickets.API
{
    public class MapperApiProfile : Profile
    {
        public MapperApiProfile()
        {
            CreateMap<FilmRequestModel, FilmInputModel>();
            CreateMap<FilmResponseModel, FilmOutputModel>();
            CreateMap<FilmOutputModel, FilmResponseModel>();
        }
    }
}
