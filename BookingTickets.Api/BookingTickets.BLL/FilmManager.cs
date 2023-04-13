using AutoMapper;
using BookingTickets.BLL.Models.OutputModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class FilmManager
    {
        //private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        //private readonly IFilmRepository _repository;

        //public FilmManager(IFilmRepository? repository = null)
        //{
        //    //_repository = repository ?? new FilmRepository();
        //}

        //public List<FilmOutputModel> GetAllFilmByCinema(CinemaOutputModel cinema)
        //{
        //    var res = _instanceMapperBll.MapCinemaBLLToCinemaDto(cinema);

        //    return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByCinema(res));
        //}

        //public List<FilmOutputModel> GetAllFilmByDay(DateTime dateTime)
        //{
        //    return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilmByDay(dateTime));
        //}

        //public List<FilmOutputModel> GetAllFilm()
        //{
        //    return _instanceMapperBll.MapListFilmDtoToListFilmBLL(_repository.GetAllFilm());
        //}

        //public void AddNewFilm(FilmOutputModel film)
        //{
        //    _repository.AddNewFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        //}

        //public void UpdateFilm(FilmOutputModel film)
        //{
        //    _repository.UpdateFilm(_instanceMapperBll.MapFilmBLLToFilmDto(film));
        //}
    }
}
