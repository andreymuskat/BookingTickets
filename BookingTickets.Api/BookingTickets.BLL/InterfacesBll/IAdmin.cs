using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.BLL.Models.All_UserBLLModels;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        void CreateSession(CreateSessionInputModel session);

        void DeleteSession(int sessionId);

        List<UserBLL> GetAllUsers();

        List<UserBLL> GetAllCashiers();

        UserBLL CreateNewCashier(CreateCashierInputModel newCashier);

        UserBLL UpdateCashier(UpdateCashierInputModel cashier);

        void DeleteCashierById(int idCashier);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);

        List<StatisticOfDaysByMonthAndYearOutputModel> StatisticOfDaysByMonthAndYear(StatisticOfDaysByMonthAndYearInputModel inputModel);
    }
}
