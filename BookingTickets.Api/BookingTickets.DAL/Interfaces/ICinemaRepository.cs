using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ICinemaRepository
    {
        CinemaDto CreateCinema(CinemaDto cinema);

        void DeleteCinemaById(int cinemaId);

        List<CinemaDto> GetAllCinema();

        CinemaDto GetCinemaById(int cinemaId);

        List<CinemaDto> GetAllCinemaByFilm(int idFilm);

        CinemaDto GetCinemaBySessionId(int sessionId);

        CinemaDto GetCinemaByHallId(int hallId);

        void EditCinema(CinemaDto cinema);
    }
}
