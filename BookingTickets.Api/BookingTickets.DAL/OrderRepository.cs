using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository()
        {
            _context = new Context();
        }

        public OrderDto CreateOrder(OrderDto order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        public OrderStatus EditOrderStatus(OrderStatus status)
        {
            return OrderStatus.Canceled;
        }
    }
}
