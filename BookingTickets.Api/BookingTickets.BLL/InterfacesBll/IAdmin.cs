using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        void CreateSession(CreateSessionInputModel session, int cinemaId);

        void DeleteSession(int sessionId);

        List<UserBLL> GetAllUsers();

        List<UserBLL> GetAllCashiers();

        UserBLL CreateNewCashier(CreateCashierInputModel newCashier);

        void DeleteCashierById(int idCashier);

        public StatisticsFilm_ForAdmin_OutputModels GetStatisticsByFilm(StatisticsFilm_ForAdmin_InputModels infoForStatic, int cinemaId);
    }
}
