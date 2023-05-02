using BookingTickets.Core.CustomException;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class FilmManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IFilmRepository _filmRepository;

        public FilmManager()
        {
            _filmRepository = new FilmRepository();
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            var searchFilm = _filmRepository.GetFilmByName(newFilm.Name);

            if (searchFilm == null)
            {
                var filmDto = _instanceMapperBll.MapFilmBLLToFilmDto(newFilm);
                
                _filmRepository.CreateFilm(filmDto);
            }
            else { throw new FilmException(105); }
        }

        public void DeleteFilm(int filmId)
        {
            _filmRepository.DeleteFilm(filmId);
        }

        public void EditFilm(FilmBLL newFilm, int filmId)
        {
            var searchFilm = _filmRepository.GetFilmById(filmId);

            if (searchFilm != null)
            {
                if (newFilm.Name != null)
                {
                    searchFilm.Name = newFilm.Name;
                }

                if (newFilm.Duration != null)
                {
                    searchFilm.Duration = newFilm.Duration;
                }

                _filmRepository.EditFilm(searchFilm);
            }
            else
            {
                throw new FilmException(777);
            }
        }

        public FilmBLL GetFilmById(int Id)
        {
            var film = _instanceMapperBll.MapFilmDtoToFilmBLL(_filmRepository.GetFilmById(Id));        
            
            if (film != null)
            {
                return film;
            }
            else { throw new FilmException(777); }
        }
    }
}
