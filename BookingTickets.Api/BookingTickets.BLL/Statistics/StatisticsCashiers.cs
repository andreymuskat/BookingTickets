using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.InputModel.All_Statistics_InputModels;
using BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Statistics
{
    public class Statistics_Cashiers: IStatisticsCashiers
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public Statistics_Cashiers()
        {
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
        }

        public List<StatisticCashiers_OutputModel> StatisticOfCashiers(StatisticCashiers_InputModel inputModel)
        {
            List<UserDto> allCashierInCinema = _userRepository.GetAllCashiersByCinemaId(inputModel.CinemaId);

            var allStatCashier = new List<StatisticCashiers_OutputModel>();

            foreach (var cashier in allCashierInCinema)
            {
                var statCashier = new StatisticCashiers_OutputModel()
                {
                    UserName = cashier.UserName,
                };
                allStatCashier.Add(statCashier);
            }

            List<OrderDto> allOrdersCashiers = _orderRepository.GetAllOrdersCashierByPeriodAndCinemaId(inputModel.DateStart, inputModel.DateEnd, inputModel.CinemaId);

            foreach (var order in allOrdersCashiers)
            {
                foreach (var cashier in allStatCashier)
                {
                    if (order.User.UserName == cashier.UserName)
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
