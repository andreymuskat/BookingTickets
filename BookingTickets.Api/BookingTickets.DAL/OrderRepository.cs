using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL
{
    public class OrderRepository : IOrderRepository
    {
        public int CreateOrder(OrderDto order)
        {
            return order.Id;
        }

        public void UpdateOrder(OrderDto order)
        {

        }

        public void DeleteOrder(int idOrder)
        {

        }

        public OrderStatus EditOrderStatus(OrderStatus status)
        {
            return OrderStatus.Canceled;
        }
    }
}
