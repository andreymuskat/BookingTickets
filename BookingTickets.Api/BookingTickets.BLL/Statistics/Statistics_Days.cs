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

        public List<StatisticOfDaysByMonthAndYearOutputModel> StatisticOfDaysByMinthAndYear(StatisticOfDaysByMonthAndYearInputModel inputModel)
        {
            List<OrderDto> allTicketsSoldMyMonth = _orderRepository.GetAllTicketsSoldByMonthOfTheYear(inputModel.Date.Year, inputModel.Date.Month, inputModel.CinemaId);

            var date = new DateTime(inputModel.Date.Year, inputModel.Date.Month, 1);
            var allDaysInTheMonth = new List<StatisticOfDaysByMonthAndYearOutputModel>();

            for (int i = 1; date.Month != inputModel.Date.Month + 1; date = date.AddDays(i))
            {
                var order = new StatisticOfDaysByMonthAndYearOutputModel() { Date = date };
                allDaysInTheMonth.Add(order);
            }

            foreach (var ticket in allTicketsSoldMyMonth)
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
