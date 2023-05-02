using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class CinemaException : Exception
    {
        private Code_Exception _errorCode;
        public Code_Exception ErrorCode { get { return _errorCode; } }

        public CinemaException(int code)
            : base()
        {
            _errorCode = (Code_Exception)(code);
        }
    }
}
