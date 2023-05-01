using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class CinemaManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ICinemaRepository _cinemaRepository;

        public CinemaManager()
        {
            _cinemaRepository = new CinemaRepository();
        }

        public void CreateCinema(CinemaBLL cinema)
        {
            _cinemaRepository.CreateCinema(_instanceMapperBll.MapCinemaBLLToCinemaDto(cinema));
        }

        public void EditCinema(CinemaBLL cinema, int cinemaId)
        {
            var searchCinema = _cinemaRepository.GetCinemaById(cinemaId);

            if (searchCinema != null)
            {
                if(cinema.Name != null)
                {
                    searchCinema.Name = cinema.Name;
                }

                if(cinema.Address != null)
                {
                    searchCinema.Address = cinema.Address;
                }
                
                _cinemaRepository.EditCinema(searchCinema);
            }
            else {  throw new CinemaException(777);}
        }

        public void DeleteCinema(int cinemaId)
        {
            _cinemaRepository.DeleteCinemaById(cinemaId);
        }

        public List<CinemaBLL> GetCinemaByFilm(int idFilm)
        {
            return _instanceMapperBll.MapListCinemaDtoToListCinemaBLL(_cinemaRepository.GetAllCinemaByFilm(idFilm));
        }

        public CinemaBLL GetCinemaByHallId(int idHallId)
        {
            return _instanceMapperBll.MapCinemaDtoToCinemaBLL(_cinemaRepository.GetCinemaByHallId(idHallId));
        }

        public List<CinemaBLL> GetAllCinema()
        {
            return _instanceMapperBll.MapListCinemaDtoToListCinemaBLL(_cinemaRepository.GetAllCinema());
        }
    }
}
