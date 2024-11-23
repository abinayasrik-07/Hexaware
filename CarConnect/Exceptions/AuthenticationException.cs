using System;

namespace CarConnect.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }
}

