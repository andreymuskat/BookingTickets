using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public OrderDto CreateOrder(OrderDto order);

        public OrderStatus EditOrderStatus(OrderStatus status);
    }
}
