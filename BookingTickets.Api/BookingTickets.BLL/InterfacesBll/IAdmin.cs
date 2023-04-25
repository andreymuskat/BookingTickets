using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
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

        void DeleteCashierById(int idCashier);
    }
}
