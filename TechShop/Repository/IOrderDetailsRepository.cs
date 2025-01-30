using System;
using TechShop.Exceptions;
using TechShop.Model;

namespace TechShop.Repository
{
    public class IOrderDetailsRepository
    {
        public void ValidateOrderDetails(Products product)
        {
            if (product == null)
                throw new IncompleteOrderException("Order detail lacks a product reference.");
        }
    }
}
