using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();

        public Admin() { }

        public void CreateSession(SessionBLL session)
        { }
    }
}
