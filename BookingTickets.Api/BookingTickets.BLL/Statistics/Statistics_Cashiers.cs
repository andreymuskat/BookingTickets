using BookingTickets.BLL.Models.All_StatisticBLLModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Statistics
{
    public class Statistics_Cashiers
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public Statistics_Cashiers()
        {
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
        }

        public List<StatisticOfCashiersOutputModel> StatisticOfCashiers(StatisticOfCashiersInputModel inputModel)
        {
            List<UserDto> allCashierInCinema = _userRepository.GetAllCashiersByCinemaId(inputModel.CinemaId);

            var allStatCashier = new List<StatisticOfCashiersOutputModel>();

            foreach(var cashier in allCashierInCinema)
            {
                StatisticOfCashiersOutputModel statCashier = new StatisticOfCashiersOutputModel()
                {
                    UserName = cashier.UserName,
                };
                allStatCashier.Add(statCashier);
            }

            List<OrderDto> allOrdersCashiers = _orderRepository.GetAllOrdersCashierByPeriodAndCinemaId(inputModel.DateStart, inputModel.DateEnd, inputModel.CinemaId);

            foreach(var order in allOrdersCashiers)
            {
                foreach(var cashier in allStatCashier)
                {
                    if(order.User.UserName == cashier.UserName)
                    {
                        cashier.SumCost += order.Session.Cost;
                        cashier.NumbersTicketsSold++;
                    }
                }
            }

            return allStatCashier;
        }
    }
}
