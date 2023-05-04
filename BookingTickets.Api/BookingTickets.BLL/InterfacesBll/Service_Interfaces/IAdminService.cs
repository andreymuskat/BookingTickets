using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;

namespace BookingTickets.BLL.InterfacesBll.Service_Interfaces
{
    public interface IAdminService
    {
        void CreateNewCashier(int cashierId, int adminCinemaId);

        void CreateSession(CreateSessionInputModel session, int cinemaId, int userId);

        void DeleteCashierById(int idCashier, int adminCinemaId);

        void DeleteSession(int sessionId);

        List<UserBLL> GetAllUsers();

        public List<UserBLL> GetAllCashiers(int adminCinemaId);

        UserBLL UpdateCashier(UpdateCashierInputModel user, int cashierId);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int cinemaId);

        List<StatisticDays_OutputModel> StatisticOfDays(StatisticDays_InputModel inputModel);

        List<StatisticCashiers_OutputModel> StatisticOfCashiers(StatisticCashiers_InputModel inputModel);


        StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic, int cinemaId);
    }
}