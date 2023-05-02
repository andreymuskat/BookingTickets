using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class SessionException: Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public SessionException(int code) 
            :base() 
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
} 
