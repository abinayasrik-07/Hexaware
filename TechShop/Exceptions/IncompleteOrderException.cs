using System;

namespace TechShop.Exceptions
{
    public class IncompleteOrderException : Exception
    {
        public IncompleteOrderException(string message) : base(message) 
        { 
        
        }
    }
}
