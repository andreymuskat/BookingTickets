using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;

namespace BookingTickets.BLL
{
    public class FilmManager : IFilmManager
    {
        private readonly INLogLogger _logger;
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;

        public FilmManager(IMapper map, IFilmRepository filmRepository, INLogLogger logger)
        {
            _filmRepository = filmRepository;
            _mapper = map;
            _logger = logger;
        }

        public void CreateNewFilm(FilmBLL newFilm)
        {
            var searchFilm = _filmRepository.GetFilmByName(newFilm.Name);

            if (searchFilm == null)
            {
                if (newFilm.Duration <= 0)
                {
                    _logger.Warn("Trying to create a film with a duration of 0 or less");

                    throw new FilmException(000);
                }
                else
                {
                    var filmDto = _mapper.Map<FilmDto>(newFilm);
                    _filmRepository.CreateFilm(filmDto);
                }
            }
            else
            {
                _logger.Warn($"Trying to create a film with a Name({newFilm.Name}) already in the database ");

                throw new FilmException(105);
            }
        }

        public void DeleteFilm(int filmId)
        {
            var searchFilm = _filmRepository.GetFilmById(filmId);

            if (searchFilm != null)
            {
                _filmRepository.DeleteFilm(filmId);
            }
            else
            {
                _logger.Warn("Trying to delete a Film that is not in the database");

                throw new FilmException(777);
            }
        }

        public void EditFilm(FilmBLL newFilm, int filmId)
        {
            var searchFilm = _filmRepository.GetFilmById(filmId);

            if (searchFilm != null)
            {
                if (newFilm.Duration <= 0)
                {
                    _logger.Warn("Trying to edit a film on duration of 0 or less");

                    throw new FilmException(000);
                }
                else
                {
                    searchFilm.Duration = newFilm.Duration;
                    searchFilm.Name = newFilm.Name;

                    _filmRepository.EditFilm(searchFilm);
                }
            }
            else
            {
                _logger.Warn("Trying to change a film that is not in the database");

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
                _logger.Warn("Object not found in database.");

                throw new FilmException(777);
            }
        }
    }
}
