using AutoMapper;
using BookingTickets.BLL.Models.InputModels;
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
                    cfg.CreateMap<FilmDto, FilmOutputModel>();
                    cfg.CreateMap<CinemaInputModel, CinemaDto>();
                });
        }

        public FilmOutputModel MapFilmDtoToFilmoutputModel(FilmDto film)
        { 
            return _configuration.CreateMapper().Map<FilmOutputModel>(film);
        }

        public CinemaDto MapCinemaInputModelToCinemaDto(CinemaInputModel cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }
    }
}
