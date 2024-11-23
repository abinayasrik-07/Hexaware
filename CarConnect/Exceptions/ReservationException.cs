using System;

namespace CarConnect.Exceptions
{
    public class ReservationException : Exception
    {
        public ReservationException(string message) : base(message) { }
    }
}

