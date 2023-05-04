using Core.Status;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BookingTickets.DAL
{
    public class CheckOrderStatusExpirationJob : IHostedService, IDisposable
    {
        private readonly Context _context;
        private Timer _timer;

        public CheckOrderStatusExpirationJob()
        {
            _context = new Context();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(CheckOrderStatusAsync, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private void CheckOrderStatusAsync(object? state)
        {
            DateTime dataYesterday = DateTime.Now.AddDays(-1);
            DateTime timeIsNeed = DateTime.Now.AddMinutes(-30);

            var allOrders = _context.Orders
                .Include(p => p.Session)
                .Where(p => p.Session.Date <= timeIsNeed && p.Session.Date > dataYesterday)
                .ToList();

            foreach ( var order in allOrders )
            {
                if (order.Status == OrderStatus.Booking)
                {
                    order.Status = OrderStatus.Canceled;

                    _context.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
