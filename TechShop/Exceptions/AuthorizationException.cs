using System;

namespace TechShop.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message) 
        { 
        
        }
    }
}
