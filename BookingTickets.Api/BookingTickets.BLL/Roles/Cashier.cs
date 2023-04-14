using BookingTickets.BLL.InterfacesBll;

namespace BookingTickets.BLL.Roles
{
    public class Cashier : IСashier
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
    }
}
