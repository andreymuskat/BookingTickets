using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL.Roles
{
    public class Client : IClient
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        public IFilmRepository _filmRepository;

        public Client()
        {
            _filmRepository = new FilmRepository();
        }

        public FilmBLL GetFilmByName(string name)
        {
            var res = _filmRepository.GetFilmByName(name);

            return _instanceMapperBll.MapFilmDtoToFilmBLL(res);
        }

        public List<SessionBLL> GetFilmsByCinema(FilmBLL film, CinemaBLL cinema) 
        {
            return new List<SessionBLL>();
        }

        public List<CinemaBLL> GetCinemaByFilm(FilmBLL film)
        {
            return new List<CinemaBLL>();
        }

        public List<SessionBLL> GetSessionsByFilm(FilmBLL film)
        {
            return new List<SessionBLL>();
        }

        public List<SeatBLL> GetFreeSeatsBySession(SessionBLL session)
        {
            return new List<SeatBLL>();
        }
    }
}
