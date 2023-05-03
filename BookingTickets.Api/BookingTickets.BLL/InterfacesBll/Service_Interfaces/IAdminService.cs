using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;

namespace BookingTickets.BLL.InterfacesBll.Service_Interfaces
{
    public interface IAdminService
    {
        UserBLL CreateNewCashier(CreateCashierInputModel newUser);

        void CreateSession(CreateSessionInputModel session, int cinemaId, int userId);

        void DeleteCashierById(int id);

        void DeleteSession(int sessionId);

        List<UserBLL> GetAllCashiers();

        List<UserBLL> GetAllUsers();

        StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic, int cinemaId);

        UserBLL UpdateCashier(UpdateCashierInputModel cashier);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);

        List<StatisticDays_OutputModel> StatisticOfDays(StatisticDays_InputModel inputModel);

        List<StatisticCashiers_OutputModel> StatisticOfCashiers(StatisticCashiers_InputModel inputModel);
    }
}