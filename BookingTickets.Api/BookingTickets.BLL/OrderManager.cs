using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;
using Core.Status;

namespace BookingTickets.BLL
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;
        private readonly INLogLogger _logger;

        public OrderManager(IMapper map, IOrderRepository orderRepository, ISeatRepository seatRepository, INLogLogger logger)
        {
            _orderRepository = orderRepository;
            _seatRepository = seatRepository;
            _mapper = map;
            _logger = logger;
        }

        public List<OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            var order = _orderRepository.FindOrderByCodeNumber(codeNumber);

            if (order != null)
            {
                return _mapper.Map<List<OrderBLL>>(order);
            }
            else
            {
                _logger.Warn("Objects not found in database.");

                throw new OrderException(777);
            }
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.EditOrderStatusByCode(status, code);
        }

        public List<OrderBLL> CreateOrderByCashier(List<CreateOrderInputModel> orders, int userId)
        {
            var orderFromOrders = orders.FirstOrDefault(x => x.SessionId > 0);

            if (orderFromOrders != null)
            {
                string CodeForClient = CreateCode(orderFromOrders);
                var resultFreeSeats = CheckSeatsInOrderWithSeatsInDB(orders, orderFromOrders.SessionId);

                if (resultFreeSeats == true)
                {
                    foreach (var order in orders)
                    {
                        order.Date = DateTime.Now;
                        order.UserId = userId;
                        order.Status = OrderStatus.Booking;
                        order.Code = CodeForClient;

                        _orderRepository.CreateOrder(_mapper.Map<OrderDto>(order));
                    }

                    var allNewOrders = _orderRepository.FindOrderByCodeNumber(CodeForClient);

                    return _mapper.Map<List<OrderBLL>>(allNewOrders);
                }
                else
                {
                    _logger.Warn("Create an order for seats that are occupied.");

                    throw new OrderException(500);
                }
            }
            else
            {
                _logger.Warn("Passed an empty value to a variable.");

                throw new OrderException(300);
            }
        }

        public string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId)
        {
            var orderFromOrders = orders.FirstOrDefault(x => x.SessionId > 0);
            if (orderFromOrders != null)
            {
                string CodeForClient = CreateCode(orderFromOrders);
                var result = CheckSeatsInOrderWithSeatsInDB(orders, orderFromOrders.SessionId);
                if (result == true)
                {
                    foreach (var order in orders)
                    {
                        order.Date = DateTime.Now;
                        order.UserId = userId;
                        order.Status = OrderStatus.Booking;
                        order.Code = CodeForClient;

                        _orderRepository.CreateOrder(_mapper.Map<OrderDto>(order));
                    }
                }

                return CodeForClient;
            }
            else
            {
                throw new OrderException(300);
            }
        }

        private string CreateCode(CreateOrderInputModel order)
        {

            Random random = new Random();
            int firstPart = random.Next(1, 1000000);
            int secondPartCode = order.SessionId;
            int thirdPartCode = order.SeatsId;
            string code = String.Concat(firstPart, secondPartCode, thirdPartCode);
            return code;

        }

        private bool CheckSeatsInOrderWithSeatsInDB(List<CreateOrderInputModel> orders, int sessionId)
        {
            bool result = true;
            List<SeatBLL> seatsInOrders = new List<SeatBLL>();
            var freeseats = _mapper.Map<List<SeatBLL>>(_seatRepository.GetAllFreeSeatsBySessionId(sessionId));


            for (int i = 0; i < orders.Count; i++)
            {
                var ss = _seatRepository.GetSeatById(orders[i].SeatsId);
                if (ss != null)
                {
                    seatsInOrders.Add(_mapper.Map<SeatBLL>(ss));
                }
                else { throw new SeatException(777); }
            }

            foreach (SeatBLL seat in seatsInOrders)
            {
                result = freeseats.Any(k => k.Id == seat.Id);

                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}

