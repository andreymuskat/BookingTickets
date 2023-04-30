using Core;

namespace BookingTickets.BLL.CustomException
{
    public class HallException : Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public HallException(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}
