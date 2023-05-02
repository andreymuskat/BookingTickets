using Core.CustomException;

namespace BookingTickets.Core.CustomException
{
    public class HallException : Exception
    {
        private Code_Exception _errorCode;
        public Code_Exception ErrorCode { get { return _errorCode; } }

        public HallException(int code)
            : base()
        {
            _errorCode = (Code_Exception)(code);
        }
    }
}
