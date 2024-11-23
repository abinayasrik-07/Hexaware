using System;

namespace CarConnect.Exceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException(string message) : base(message) { }
    }
}

