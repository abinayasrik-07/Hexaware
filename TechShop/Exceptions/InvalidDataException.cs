using System;
using TechShop.Repository;
using TechShop.Main_Module;

namespace TechShop.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message) : base(message) 
        { 
        
        }
    }
}
