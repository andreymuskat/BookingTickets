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

        public List<StaticticOfDaysByMonthAndYearOutputModel> StatisticOfDaysByMinthAndYear(StatisticOfDaysByMonthAndYearInputModel inputModel)
        {
            var orderDto = new OrderDto() {
                Date = new DateTime(inputModel.Date.Year, inputModel.Date.Month, 1),
                Session = new SessionDto() { 
                    Hall = new HallDto() { 
                        CinemaId = inputModel.CinemaId} }
            };

            List<OrderDto> allTicketsSoldMyMonth = _orderRepository.GetAllTicketsSoldByMonthOfTheYear(inputModel.Date.Year, inputModel.Date.Month, inputModel.CinemaId);

            var date = new DateTime(inputModel.Date.Year, inputModel.Date.Month, 0);
            var allDaysInTheMonth = new List<StaticticOfDaysByMonthAndYearOutputModel>();

            for (int i = 1; date.Month != inputModel.Date.Month + 1; date = date.AddDays(i))
            {
                var order = new StaticticOfDaysByMonthAndYearOutputModel() { Date = date };
                allDaysInTheMonth.Add(order);
            }

            foreach (var ticket in allTicketsSoldMyMonth)
            {
                foreach(var i in allDaysInTheMonth)
                {
                    if(i.Date.Month == ticket.Date.Month && i.Date.Year == ticket.Date.Year)
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
