using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface ISessionManager
    {
        void CreateSession(CreateSessionInputModel newSession);

        void DeleteSession(int idSession);

        List<SessionBLL> GetAllSessionByCinemaAndFilm(int cinemaId, int filmId);

        List<SessionBLL> GetAllSessionByCinemaId(int idCinema);

        List<SessionBLL> GetAllSessionByFilmId(int idFilm);

        SessionOutputModel GetSessionById(int idSession);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);
    }
}