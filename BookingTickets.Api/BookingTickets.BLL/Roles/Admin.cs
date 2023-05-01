using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.BLL.Models.All_UserBLLModels;
using BookingTickets.BLL.Statistics;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;
        private readonly UserManager _userManager;
        private readonly Statistics_Days _statisticDays;

        public Admin()
        {
            _sessionManager = new SessionManager();
            _userManager = new UserManager();
            _statisticDays = new Statistics_Days();
        }

        public void CreateSession(CreateSessionInputModel session)
        {
            _sessionManager.CreateSession(session);
        }

        public void DeleteSession(int sessionId)
        {
            _sessionManager.DeleteSession(sessionId);

        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userManager.GetAllUsers();

            return allUsers;
        }

        public List<UserBLL> GetAllCashiers()
        {
            var allUsers = _userManager.GetAllCashiers();

            return allUsers;
        }

        public UserBLL CreateNewCashier(CreateCashierInputModel newUser)
        {
            var res = _userManager.CreateNewCashier(newUser);

            return res;
        }

        public UserBLL UpdateCashier(UpdateCashierInputModel user)
        {
            var res = _userManager.UpdateCashier(user);

            return res;
        }

        public void DeleteCashierById(int id)
        {
            _userManager.DeleteCashierById(id);
        }

        public void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId)
        {
            _userManager.CopySession(dateCopy, dateWhereToCopy, CinemaId);
        }

        public List<StatisticOfDaysByMonthAndYearOutputModel> StatisticOfDaysByMonthAndYear(StatisticOfDaysByMonthAndYearInputModel inputModel)
        {
            var res = _statisticDays.StatisticOfDaysByMinthAndYear(inputModel);
            return res;
        }
    }
}
