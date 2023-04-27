using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public void EditOrderStatus(OrderStatus status, string code)
        {
            var order = _context.Orders.Where(i=>i.Code == code);
            foreach (var item in order)
            {
             item.Status = status;
            _context.SaveChanges();
            }
        }

        public List <OrderDto> FindOrderByCodeNumber(string codeNumber)
        {
            return _context.Orders
                    .Where (p => p.Code == codeNumber)
                    .Include(p=>p.Session)
                    .Include(p=>p.Seats )
                    .Include(p=>p.User )
                    .ToList ();
        }
    }
}