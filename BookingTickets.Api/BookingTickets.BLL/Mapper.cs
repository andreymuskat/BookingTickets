using AutoMapper;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;
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
                    cfg.CreateMap<HallDto, FullHallOutputModel>();
                    cfg.CreateMap<HallInputModel, HallDto>();
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

        public FullHallOutputModel MapHallDtoToFullHallOutputModel(HallDto hall)
        {
            return _configuration.CreateMapper().Map<FullHallOutputModel>(hall);
        }

        public HallDto MapHallInputModelToHallDto(HallInputModel hall)
        {
            return _configuration.CreateMapper().Map<HallDto>(hall);
        }
    }
}
