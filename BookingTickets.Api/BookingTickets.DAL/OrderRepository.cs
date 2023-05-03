using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;
using Core.Status;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly INLogLogger _logger;
        private readonly Context _context;

        public OrderRepository(INLogLogger logger)
        {
            _context = new Context();
            _logger = logger; 
        }

        public void CreateOrder(OrderDto order)
        {
            _context.Orders.Add(order);

            _context.SaveChanges();

            _logger.Info($"Order on session(Id - {order.SessionId}) create and written to the database.");
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

        public List<OrderDto> GetAllTicketsSold(DateTime dateStart, DateTime dateEnd)
        {
            var result = new List<OrderDto>();

            result = _context.Orders
                .Where(t => t.Status == OrderStatus.PurchasedByCashbox || t.Status == OrderStatus.PurchasedBySite)
                .Where(t => t.Date >= dateStart && t.Date <= dateEnd)
                .Include(h => h.Session)
                .Include(h => h.Seats.Hall.Cinema)
                .ToList();

            return result;
        }

        public List<OrderDto> GetAllOrdersCashierByPeriodAndCinemaId(DateTime dateStart, DateTime dateEnd, int cinemaId)
        {
            var result = new List<OrderDto>();

            result = _context.Orders
                .Where(t => t.User.UserStatus == UserStatus.CashierService)
                .Where(t => t.Status == OrderStatus.PurchasedByCashbox)
                .Where(t => t.Session.Hall.Cinema.Id == cinemaId)
                .Where(t => t.Date >= dateStart && t.Date <= dateEnd)
                .Include(h => h.Session)
                .Include(h => h.User)
                .ToList();

            return result;
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