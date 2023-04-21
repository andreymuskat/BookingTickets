using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        public void CreateSession(SessionBLL session);

        public void CreateCashier(UserBLL cashier);

        public List<UserBLL> GetAllUsers();
    }
}
