using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Statistics
{
    public class Statistics_Days
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;
        private readonly SessionManager _sessionManager;

        public Statistics_Days()
        {
            _orderRepository = new OrderRepository();
            _sessionManager = new SessionManager();
        }

        public List<StatisticOfDaysOutputModel> StatisticOfDays(StatisticOfDaysInputModel inputModel)
        {
            List<OrderDto> allTicketsSold = _orderRepository.GetAllTicketsSold(inputModel.DateStart, inputModel.DateEnd, inputModel.CinemaId);

            var date = new DateTime(inputModel.DateStart.Year, inputModel.DateStart.Month, inputModel.DateStart.Day);
            var allDaysInTheMonth = new List<StatisticOfDaysOutputModel>();

            for (int i = 1; date <= inputModel.DateEnd; date = date.AddDays(i))
            {
                var order = new StatisticOfDaysOutputModel() { Date = date };
                allDaysInTheMonth.Add(order);
            }

            foreach (var ticket in allTicketsSold)
            {
                foreach(var i in allDaysInTheMonth)
                {
                    if(i.Date.Month == ticket.Date.Month && i.Date.Year == ticket.Date.Year && i.Date.Day == ticket.Date.Day)
                    {
                        i.SumCost += ticket.Session.Cost;
                        i.NumbersTicketsSold++;
                    }
                }
            }

            return allDaysInTheMonth;
        }
    }
}
