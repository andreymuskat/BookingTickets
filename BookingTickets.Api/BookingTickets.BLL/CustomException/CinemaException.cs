using Core;

namespace BookingTickets.BLL.CustomException
{
    public class CinemaException : Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public CinemaException(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}
