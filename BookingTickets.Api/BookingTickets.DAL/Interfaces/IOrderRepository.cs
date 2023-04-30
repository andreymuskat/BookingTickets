using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(OrderDto order);

        public void EditOrderStatus(OrderStatus status, string code);

        public List <OrderDto> FindOrderByCodeNumber(string codeNumber);
    }
}
