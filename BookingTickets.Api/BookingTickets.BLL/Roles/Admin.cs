using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;
        private readonly UserManager _userManager;

        public Admin() 
        {
            _sessionManager = new SessionManager();
            _userManager = new UserManager();
        }

        public void CreateSession(SessionBLL session)
        {
            _sessionManager.CreateSession(session);
        }

        public void CreateCashier(UserBLL user)
        {
            
        }
        
        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userManager.GetAllUsers();

            return allUsers;
        }
    }
}
