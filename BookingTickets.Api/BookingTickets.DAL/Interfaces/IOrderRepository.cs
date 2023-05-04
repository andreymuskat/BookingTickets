using BookingTickets.DAL.Models;
using Core.Status;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderDto order);

        void EditOrderStatusByCode(OrderStatus status, string code);

        List<OrderDto> FindOrderByCodeNumber(string codeNumber);

        List<OrderDto> GetAllTicketsSold(DateTime dateStart, DateTime dateEnd);

        List<OrderDto> GetAllOrdersCashierByPeriodAndCinemaId(DateTime dateStart, DateTime dateEnd, int cinemaId);

        List<OrderDto> GetAllOrdersByDate(DateTime data);

        void EditOrderStatus(OrderDto order, OrderStatus newStatus);

        OrderDto GetOrderById(int id);

        void EditOrderStatusById(int id, OrderStatus status);
    }
}
