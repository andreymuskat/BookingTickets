using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IUserManager
    {
        void ChangeUserStatus(UserStatus status, int userId);

        UserBLL CreateNewCashier(CreateCashierInputModel user);

        void DeleteCashierById(int idCashier);

        List<UserBLL> GetAllCashiers();

        List<UserBLL> GetAllUsers();

        UserBLL GetUserById(int userId);

        UserBLL GetUserByName(string name);
    }
}