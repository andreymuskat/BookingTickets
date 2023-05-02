using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL
{
    public class FilmManager : IFilmManager
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;

        public FilmManager(IMapper map, IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
            _mapper = map;
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            var searchFilm = _filmRepository.GetFilmByName(newFilm.Name);

            if (searchFilm == null)
            {
                var filmDto = _mapper.Map<FilmDto>(newFilm);

                _filmRepository.CreateFilm(filmDto);
            }
            else
            {
                throw new FilmException(105);
            }
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
            var film = _mapper.Map<FilmBLL>(_filmRepository.GetFilmById(Id));

            if (film != null)
            {
                return film;
            }
            else
            {
                throw new FilmException(777);
            }
        }
    }
}
