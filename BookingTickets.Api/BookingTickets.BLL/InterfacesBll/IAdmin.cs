using BookingTickets.BLL.Models.All_SessionBLLModel;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        public void CreateSession(SessionBLL session);

        public void CreateCashier(UserBLL cashier);

        public List<UserBLL> GetAllUsers();
    }
}

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IAdmin
    {
        public void CreateSession(CreateSessionInputModel session);

        public void DeleteSession(int sessionId);
    }
}
