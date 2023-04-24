using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(OrderDto order);

        public OrderStatus EditOrderStatus(OrderStatus status);
        public OrderDto FindOrderByCodeNumber(string codeNumber);
    }
}
