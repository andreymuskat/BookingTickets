using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class FilmException: Exception
    {
        private CodeExceptionType _errorCode;
        public CodeExceptionType ErrorCode { get { return _errorCode; } }

        public FilmException(int code)
            : base()
        {
            _errorCode = (CodeExceptionType)(code);
        }
    }
}
