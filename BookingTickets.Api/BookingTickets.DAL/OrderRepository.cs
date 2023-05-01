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

        public List<OrderDto> GetAllTicketsSoldByMonthOfTheYear(int year, int month , int cinemaId)
        {
            var result = new List<OrderDto>();

            result = _context.Orders
                .Where(t => t.Status == Core.OrderStatus.PurchasedByСashbox || t.Status == Core.OrderStatus.PurchasedBySite)
                .Where(t => t.Session.Hall.CinemaId == cinemaId)
                .Where(t => t.Session.Date.Year == year)
                .Where(t => t.Session.Date.Month == month)
                .ToList();

            return result;
        }
    }
}
