using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class SessionException: Exception
    {
        private Code_Exception _errorCode;
        public Code_Exception ErrorCode { get { return _errorCode; } }

        public SessionException(int code) 
            :base() 
        {
            _errorCode = (Code_Exception)(code);
        }
    }
} 
