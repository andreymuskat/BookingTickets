using AutoMapper;

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
                });
        }

        public FilmOutputModel MapFilmDtoToFilmoutputModel(FilmDto film)
        { 
            return _configuration.CreateMapper().Map<FilmOutputModel>(film);
        }
    }
}
