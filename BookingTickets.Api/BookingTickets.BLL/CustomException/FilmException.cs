using Core;

namespace BookingTickets.BLL.CustomException
{
    public class FilmException : Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public FilmException(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}
