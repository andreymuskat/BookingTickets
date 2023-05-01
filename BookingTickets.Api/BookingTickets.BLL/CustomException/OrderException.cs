using Core;

namespace BookingTickets.BLL.CustomException
{
    public class OrderException : Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public OrderException(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}
