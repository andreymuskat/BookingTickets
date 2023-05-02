using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core;
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
            var order = _context.Orders
                .Where(i => i.Code == code)
                .ToList();

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
                    .Include(p => p.Session.Film)
                    .Include(p => p.Session.Hall)
                    .Include(p => p.Session.Hall.Cinema)
                    .Include(p=>p.Seats)
                    .Include(p=>p.User)
                    .ToList();
        }

        public List<OrderDto> GetAllTicketsSold(DateTime dateStart, DateTime dateEnd, int cinemaId)
        {
            var result = new List<OrderDto>();
            
            result = _context.Orders
                .Where(t => t.Status == Core.OrderStatus.PurchasedByСashbox || t.Status == Core.OrderStatus.PurchasedBySite)
                .Where(t => t.Session.Hall.Cinema.Id == cinemaId)
                .Where(t => t.Date >= dateStart && t.Date <= dateEnd )
                .Include(h => h.Session)
                .ToList();

            return result;
        }

        public List<OrderDto> GetAllOrdersCashierByPeriodAndCinemaId(DateTime dateStart, DateTime dateEnd, int cinemaId)
        {
            var result = new List<OrderDto>();

            result = _context.Orders
                .Where(t => t.User.UserStatus == Core.UserStatus.Cashier)
                .Where(t => t.Status == Core.OrderStatus.PurchasedByСashbox)
                .Where(t => t.Session.Hall.Cinema.Id == cinemaId)
                .Where(t => t.Date >= dateStart && t.Date <= dateEnd)
                .Include(h => h.Session)
                .Include(h => h.User)
                .ToList();

            return result;
        }
    }
}