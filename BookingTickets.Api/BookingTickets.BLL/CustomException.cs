namespace BookingTickets.BLL
{
    public class ExceptionSession : ApplicationException
    {
        public ExceptionSession() { }

        public ExceptionSession(string message)
            : base(message) { }

        public ExceptionSession(string message, Exception inner)
            : base(message, inner) { }
    }

    public class ExceptionFilm : ApplicationException
    {
        public ExceptionFilm() { }

        public ExceptionFilm(string message)
            : base(message) { }

        public ExceptionFilm(string message, Exception inner)
            : base(message, inner) { }
    }
}
