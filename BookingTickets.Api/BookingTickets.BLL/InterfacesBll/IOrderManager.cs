using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IOrderManager
    {
        List<OrderBLL> CreateOrderByCashier(List<CreateOrderInputModel> orders, int userId);

        List<OrderBLL> CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId);

        void EditOrderStatus(OrderStatus status, string code);

        List<OrderBLL> FindOrdersByCodeNumber(string codeNumber);

        OrderBLL GetOrderById(int id);

        public void EditOrderStatusById(int id, OrderStatus status);
    }
}