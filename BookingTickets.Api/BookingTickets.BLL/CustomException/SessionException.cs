using Core;

namespace BookingTickets.BLL.CustomException
{
    public class SessionException: Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public SessionException(int code) 
            :base() 
        {
            _errorCode = (CodeException)(code);
        }
    }
} 
