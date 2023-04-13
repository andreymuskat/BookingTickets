using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL.Roles
{
    public class Client : IClient
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private IFilmRepository _filmRepository;

        public Client(IFilmRepository repository)
        {
            _filmRepository = repository;
        }

        public FilmBLL GetFilmByName(string name)
        {
            var res = _filmRepository.GetFilmByName(name);

            return _instanceMapperBll.MapFilmDtoToFilmBLL(res);
        }
    }
}
