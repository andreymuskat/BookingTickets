using BookingTickets.Core.CustomException;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Order_InputModels;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using Core.Status;

namespace BookingTickets.BLL
{
    public class OrderManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IOrderRepository _orderRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IAuthRepository _authRepository;

        public OrderManager()
        {
            _orderRepository = new OrderRepository();
            _sessionRepository = new SessionRepository();
            _seatRepository = new SeatRepository();
            _authRepository = new AuthRepository();
        }

        public List<OrderBLL> FindOrdersByCodeNumber(string codeNumber)
        {
            return _instanceMapperBll.MapCreateListOrderDtoModelToListOrderBll(_orderRepository.FindOrderByCodeNumber(codeNumber));
        }

        public void EditOrderStatus(OrderStatus status, string code)
        {
            _orderRepository.EditOrderStatus(status, code);
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
                    _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
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

                    _orderRepository.CreateOrder(_instanceMapperBll.MapCreateOrderInputModelToOrderDto(order));
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
            var freeseats = _instanceMapperBll.MapListSeatDtoToListSeatBLL(_seatRepository.GetAllFreeSeatsBySessionId(sessionId));

            for (int i = 0; i < orders.Count; i++)
            {
                var ss = _seatRepository.GetSeatById(orders[i].SeatsId);
                if(ss != null)
                {
                    seatsInOrders.Add(_instanceMapperBll.MapSeatDtoToSeatBLL(ss));
                }
                else { throw new SeatException(777); }
            }

            foreach (SeatBLL seat in seatsInOrders)
            {
                bool found = false;

                foreach (SeatBLL seatFree in freeseats)
                {
                    if (seat.Id == seatFree.Id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}

