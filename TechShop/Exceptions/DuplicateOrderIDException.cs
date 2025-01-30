using System;

namespace TechShop.Exceptions
{
    public class DuplicateOrderIDException : Exception
    {
        public DuplicateOrderIDException(string message) : base(message) { }
    }
}

