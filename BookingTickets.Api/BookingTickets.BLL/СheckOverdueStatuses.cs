﻿using BookingTickets.DAL;
using Core.Status;

namespace BookingTickets.BLL
{
    public class СheckOverdueStatuses
    {
        private readonly OrderRepository _orderRepository;

        public СheckOverdueStatuses()
        {
            _orderRepository = new OrderRepository();
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
