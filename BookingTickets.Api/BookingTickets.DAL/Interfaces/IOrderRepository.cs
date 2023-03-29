using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public int CreateOrder(OrderDto order);

        public void UpdateOrder(OrderDto order);

        public void DeleteOrder(int idOrder);

        public OrderStatus EditOrderStatus(OrderStatus status);
    }
}
