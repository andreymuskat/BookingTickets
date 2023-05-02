using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface ICinemaManager
    {
        void CreateCinema(CinemaBLL cinema);

        void DeleteCinema(int cinemaId);

        void EditCinema(CinemaBLL cinema, int cinemaId);

        List<CinemaBLL> GetAllCinema();

        List<CinemaBLL> GetCinemaByFilm(int idFilm);

        CinemaBLL GetCinemaByHallId(int idHallId);
    }
}