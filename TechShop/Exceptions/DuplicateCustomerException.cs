using System;

namespace TechShop.Exceptions
{
    public class DuplicateCustomerException : Exception
    {
        public DuplicateCustomerException(string message) : base(message) { }
    }
}

