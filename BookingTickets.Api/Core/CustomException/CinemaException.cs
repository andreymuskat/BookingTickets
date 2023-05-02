using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class CinemaException : Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public CinemaException(int code)
            : base()
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
}
