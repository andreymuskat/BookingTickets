using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class UserExceptions : Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public UserExceptions(int code)
            : base()
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
}
