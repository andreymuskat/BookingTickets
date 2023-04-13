using BookingTickets.BLL.InterfacesBll;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();

        public Admin() { }
    }
}
