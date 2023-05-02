using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using Core.Status;

namespace BookingTickets.BLL.InterfacesBll
{
    public interface IOrderManager
    {
        void CreateOrderByCashier(List<CreateOrderInputModel> orders, int userId);

        string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId);

        void EditOrderStatus(OrderStatus status, string code);

        List<OrderBLL> FindOrdersByCodeNumber(string codeNumber);
    }
}