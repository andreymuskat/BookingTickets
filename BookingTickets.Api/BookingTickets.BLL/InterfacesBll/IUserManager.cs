using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IUserManager
    {
        void ChangeUserStatus(UserStatus status, int userId);

        void DeleteCashierById(int idCashier, int adminCinemaId);

        List<UserBLL> GetAllCashiers();

        List<UserBLL> GetAllUsers();

        UserBLL GetUserById(int userId);

        UserBLL GetCashierById(int cashierId);

        UserBLL GetUserByName(string name);

        UserBLL UpdateCashier(UpdateCashierInputModel user, int cashierId);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);
    }
}