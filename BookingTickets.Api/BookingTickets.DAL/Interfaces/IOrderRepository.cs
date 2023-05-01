using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        OrderDto CreateOrder(OrderDto order);

        OrderStatus EditOrderStatus(OrderStatus status);

        List<OrderDto> GetAllTicketsSoldByMonthOfTheYear(int year, int month, int cinemaId);
    }
}
