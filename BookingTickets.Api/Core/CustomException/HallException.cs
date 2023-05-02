using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class HallException : Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public HallException(int code)
            : base()
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
}
