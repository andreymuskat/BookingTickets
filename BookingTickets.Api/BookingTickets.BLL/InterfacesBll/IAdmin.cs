using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        void CreateSession(CreateSessionInputModel session, int cinemaId, int userId);

        void DeleteSession(int sessionId);

        List<UserBLL> GetAllUsers();

        List<UserBLL> GetAllCashiers();

        UserBLL CreateNewCashier(CreateCashierInputModel newCashier);

        UserBLL UpdateCashier(UpdateCashierInputModel user);

        void DeleteCashierById(int idCashier);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);

        List<StatisticOfDaysOutputModel> StatisticOfDays(StatisticOfDaysInputModel inputModel);

        List<StatisticOfCashiersOutputModel> StatisticOfCashiers(StatisticOfCashiersInputModel inputModel);

        public StatisticsFilm_OutputModels GetStatisticsByFilm(StatisticsFilm_InputModels infoForStatic, int cinemaId);
    }
}
