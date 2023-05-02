using Core;

namespace BookingTickets.BLL.CustomException
{
    public class UserExceptions : Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public UserExceptions(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}
