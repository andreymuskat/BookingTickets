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

        public OrderStatus EditOrderStatus(OrderStatus status, string code)
        {
            var order = _context.Orders.Single(i=>i.Code == code).Status = status;
            _context.SaveChanges();
            return order;
        }

        public OrderDto FindOrderByCodeNumber(string codeNumber)
        {
            return _context.Orders
                    .Single(p => p.Code == codeNumber);
        }
    }
}