using System;

namespace TechShop.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message) : base(message) 
        { 
        
        }
    }
}
