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

        public void CreateOrder(OrderDto order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public OrderStatus EditOrderStatus(OrderStatus status)
        {
            return OrderStatus.Canceled;
        }


        //_____________


        public OrderDto FindOrderByCodeNumber(string codeNumber)
        {
            return _context.Orders
                    .Single(p => p.Code == codeNumber);
        }
    }
}