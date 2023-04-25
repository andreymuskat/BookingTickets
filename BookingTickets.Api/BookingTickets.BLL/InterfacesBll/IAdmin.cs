using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        public void CreateSession(CreateSessionInputModel session);

        public void DeleteSession(int sessionId);

        public List<UserBLL> GetAllUsers();

        public List<UserBLL> GetAllCashiers();
    }
}
