using BookingTickets.BLL.Models.InputModels;
using BookingTickets.BLL.NewFolder;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTickets.BLL
{
    public class MainAdmin: IMainAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private IFilmRepository _filmRepository;

        public MainAdmin(IFilmRepository repository)
        {
            _filmRepository = repository;
        }

        public void AddNewFilm(FilmInputModel newFilm)
        {
            var filmDto = _instanceMapperBll.MapFilmInputModelToFilmDto(newFilm);
            var filmByName = _filmRepository.GetFilmByName(filmDto.Name);
            if (filmByName == null)
            {
                _filmRepository.CreateFilm(filmDto);
            }
            else
            {
                throw new Exception("Такой фильм уже есть в базе!");
            }
        }
    }
}
