﻿using System;

namespace TechShop.Exceptions
{
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message) : base(message) 
        { 
        
        }
    }
}
