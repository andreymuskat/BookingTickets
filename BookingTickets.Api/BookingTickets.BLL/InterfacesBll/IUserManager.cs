using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IUserManager
    {
        void ChangeUserStatus(UserStatus status, int userId);

        void ChangeUserCinemaId(int cinemaId, int userId);

        void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId);

        void DeleteCashierById(int idCashier, int adminCinemaId);

        List<UserBLL> GetAllCashiers();

        List<UserBLL> GetAllUsers();

        UserBLL GetCashierById(int cashierId);

        UserBLL GetUserById(int userId);

        UserBLL GetUserByName(string name);

        UserBLL UpdateCashier(UpdateCashierInputModel cashier, int cashierId);
    }
}