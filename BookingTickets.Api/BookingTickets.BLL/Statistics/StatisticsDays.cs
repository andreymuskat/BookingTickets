using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.DAL.Models;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.InterfacesBll;

namespace BookingTickets.BLL.Statistics
{
    public class StatisticsDays: IStatisticsDays
    {
        private readonly IOrderRepository _orderRepository;

        public StatisticsDays()
        {
            _orderRepository = new OrderRepository();
        }

        public List<StatisticDays_OutputModel> StatisticOfDays(StatisticDays_InputModel inputModel)
        {
            List<OrderDto> allTicketsSold = _orderRepository.GetAllTicketsSold(inputModel.DateStart, inputModel.DateEnd)
                .Where(t => t.Seats.Hall.Cinema.Id == inputModel.CinemaId)
                .ToList();

            var date = new DateTime(inputModel.DateStart.Year, inputModel.DateStart.Month, inputModel.DateStart.Day);
            var allDaysInTheMonth = new List<StatisticDays_OutputModel>();

            for (int i = 1; date <= inputModel.DateEnd; date = date.AddDays(i))
            {
                var order = new StatisticDays_OutputModel() { Date = date };
                allDaysInTheMonth.Add(order);
            }

            foreach (var ticket in allTicketsSold)
            {
                foreach (var i in allDaysInTheMonth)
                {
                    if (i.Date.Month == ticket.Date.Month && i.Date.Year == ticket.Date.Year && i.Date.Day == ticket.Date.Day)
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
