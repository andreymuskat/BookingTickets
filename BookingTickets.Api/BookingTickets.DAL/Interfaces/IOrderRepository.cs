using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        OrderDto CreateOrder(OrderDto order);

        OrderStatus EditOrderStatus(OrderStatus status);

        List<OrderDto> GetAllTicketsSold(DateTime dateStart, DateTime dateEnd, int cinemaId);

        List<OrderDto> GetAllOrdersCashierByPeriodAndCinemaId(DateTime dateStart, DateTime dateEnd, int cinemaId);
    }
}
