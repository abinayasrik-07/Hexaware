using System;
using TechShop.Exceptions;

namespace TechShop.Repository
{
    public class IInventoryRepository
    {
        private int stock = 50;

        public void ProcessOrder(int orderQuantity)
        {
            if (orderQuantity > stock)
                throw new InsufficientStockException("Order quantity exceeds available stock.");

            stock -= orderQuantity;
            Console.WriteLine("Order processed successfully.");
        }
    }
}
