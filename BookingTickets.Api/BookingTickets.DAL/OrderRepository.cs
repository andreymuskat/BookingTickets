using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.Status;
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

        public void EditOrderStatusByCode(OrderStatus status, string code)
        {
            var order = _context.Orders
                .Where(i => i.Code == code)
                .ToList();

            foreach (var item in order)
            {
                item.Status = status;
                _context.SaveChanges();
            }
        }

        public List<OrderDto> FindOrderByCodeNumber(string codeNumber)
        {
            return _context.Orders
                    .Where(p => p.Code == codeNumber)
                    .Include(p => p.Session)
                    .Include(p => p.Session.Film)
                    .Include(p => p.Session.Hall)
                    .Include(p => p.Session.Hall.Cinema)
                    .Include(p => p.Seats)
                    .Include(p => p.User)
                    .ToList();
        }

        public async Task<List<OrderDto>> GetAllOrdersByDate(DateTime data)
        {
            return await _context.Orders
                .Where(p => p.Date == data)
                .ToListAsync();
        }

        public async Task EditOrderStatus(OrderDto order, OrderStatus newStatus)
        {
            var searchOrder = _context.Orders
                .Single(k => k.Id == order.Id);

            searchOrder.Status = newStatus;

            await _context.SaveChangesAsync();
        }
    }
}