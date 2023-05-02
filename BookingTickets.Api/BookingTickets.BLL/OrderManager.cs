using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.Status;

namespace BookingTickets.BLL
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public OrderManager(IMapper map, IOrderRepository orderRepository, ISeatRepository seatRepository)
        {
            _orderRepository = orderRepository;
            _seatRepository = seatRepository;
            _mapper = map;
        }

        public List<OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            return _mapper.Map<List<OrderBLL>>(_orderRepository.FindOrderByCodeNumber(codeNumber));
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.EditOrderStatusByCode(status, code);
        }

        public void CreateOrderByCashier(List<CreateOrderInputModel> orders, int userId)
        {
            var result = CheckSeatsInOrderWithSeatsInDB(orders, orders[0].SessionId);

            int secondPartCode = orders[0].SessionId;
            int thirdPartCode = orders[0].SeatsId;
            string CodeForClient = CreateCode(secondPartCode, thirdPartCode);

            if (result == true)
            {
                foreach (var order in orders)
                {
                    order.Date = DateTime.Now;
                    order.UserId = userId;
                    order.Status = OrderStatus.PurchasedByСashbox;
                    order.Code = CodeForClient;
                    _orderRepository.CreateOrder(_mapper.Map<OrderDto>(order));
                }
            }
            else { throw new SessionException(500); }
        }

        public string CreateOrderByCustomer(List<CreateOrderInputModel> orders, int userId)
        {
            var result = CheckSeatsInOrderWithSeatsInDB(orders, orders[0].SessionId);

            int secondPartCode = orders[0].SessionId;
            int thirdPartCode = orders[0].SeatsId;
            string CodeForClient = CreateCode(secondPartCode, thirdPartCode);

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
            else { throw new SessionException(500); }

            return CodeForClient;
        }

        private string CreateCode(int secondPartCode, int thirdPartCode)
        {
            Random random = new Random();
            int firstPart = random.Next(1, 1000000);
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

