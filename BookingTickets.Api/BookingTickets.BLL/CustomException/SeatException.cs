﻿using Core;

namespace BookingTickets.BLL.CustomException
{
    public class SeatException: Exception
    {
        private CodeException _errorCode;
        public CodeException ErrorCode { get { return _errorCode; } }

        public SeatException(int code)
            : base()
        {
            _errorCode = (CodeException)(code);
        }
    }
}