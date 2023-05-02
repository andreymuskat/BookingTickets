using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class SeatException: Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public SeatException(int code)
            : base()
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
}
