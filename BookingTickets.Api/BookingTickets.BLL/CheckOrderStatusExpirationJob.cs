using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using Core.Status;

namespace BookingTickets.BLL
{
    public class CheckOrderStatusExpirationJob
    {
        private readonly IOrderRepository _orderRepository;

        public CheckOrderStatusExpirationJob(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task StartCheck()
        {
            while (true)
            {
                await CheckOrderStatusAsync();

                await Task.Delay(60 * 1000);
            }
        }

        public async Task CheckOrderStatusAsync()
        {
            DateTime timeIsNeed = DateTime.Now.AddMinutes(-30);

            var allOrders = await _orderRepository.GetAllOrdersByDate(timeIsNeed);

            for (var i = 0; i < allOrders.Count; i++)
            {
                if (allOrders[i].Session.Date < timeIsNeed)
                {
                    await _orderRepository.EditOrderStatus(allOrders[i], OrderStatus.Canceled);
                }
            }
        }
    }
}
