using AutoMapper;
using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.Models.OutputModels;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class MapperBLL
    {
        private readonly MapperConfiguration _configuration;

        public MapperBLL()
        {
            _configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<FilmDto, FilmBLL>();
                    //cfg.CreateMap<FilmDto, FilmResponseModel>();
                    //cfg.CreateMap<FilmResponseModel, FilmDto>();
                    cfg.CreateMap<CinemaInputModel, CinemaDto>();
                    cfg.CreateMap<HallDto, FullHallOutputModel>();
                    cfg.CreateMap<HallInputModel, HallDto>();
                    //cfg.CreateMap<FilmRequestModel, FilmDto>();
                    cfg.CreateMap<CinemaBLL, CinemaDto>();
                });
        }

        public List<FilmBLL> MapListFilmDtoToListFilmBLL(List<FilmDto> film)
        {
            return _configuration.CreateMapper().Map<List<FilmBLL>>(film);
        }


        //public FilmResponseModel MapFilmDtoToFilmResponseModel(FilmDto film)
        //{ 
        //    return _configuration.CreateMapper().Map<FilmResponseModel>(film);
        //}

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

        //public FilmRequestModel MapFilmDtoToFilmRequestModel(FilmDto film)
        //{
        //    return _configuration.CreateMapper().Map<FilmRequestModel>(film);
        //}

        public CinemaDto MapCinemaBLLToCinemaDto(CinemaBLL cinema)
        {
            return _configuration.CreateMapper().Map<CinemaDto>(cinema);
        }
    }
}
