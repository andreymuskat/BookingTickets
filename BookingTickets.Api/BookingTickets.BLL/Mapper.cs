using AutoMapper;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class MapperX
    {
        private readonly MapperConfiguration _configuration;

        public MapperX()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<FilmDto, FilmOutputModel>
                });
        }
    }
}
