using BookingTickets.DAL.Models;
using Core.Status;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderDto order);

        void EditOrderStatusByCode(OrderStatus status, string code);

        List<OrderDto> FindOrderByCodeNumber(string codeNumber);

        Task<List<OrderDto>> GetAllOrdersByDate(DateTime data);

        Task EditOrderStatus(OrderDto order, OrderStatus newStatus);
    }
}
