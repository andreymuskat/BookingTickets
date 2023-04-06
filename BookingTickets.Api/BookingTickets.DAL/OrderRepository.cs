using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public OrderDto CreateOrder(OrderDto order)
        {
            _context.Orders.Add(order);

            _context.SaveChanges();

            return order;
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
