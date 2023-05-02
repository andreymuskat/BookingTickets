using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.DAL.Interfaces
{
    public interface IOrderRepository
    {
        public void CreateOrder(OrderDto order);

        public void EditOrderStatus(OrderStatus status, string code);

        public List <OrderDto> FindOrderByCodeNumber(string codeNumber);

        List<OrderDto> GetAllTicketsSold(DateTime dateStart, DateTime dateEnd, int cinemaId);

        List<OrderDto> GetAllOrdersCashierByPeriodAndCinemaId(DateTime dateStart, DateTime dateEnd, int cinemaId);
    }
}
