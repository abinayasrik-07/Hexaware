using System;
using TechShop.Exceptions;
using TechShop.Service;
using TechShop.Repository;

namespace TechShop.Main_Module
{
    public class Program
    {
        static void Main()
        {
            var customerService = new ICustomerRepository();
            var inventoryService = new IInventoryRepository();
            var orderService = new IOrderDetailsRepository();
            var paymentService = new IPaymentRepository();
            var logger = new ILoggingRepository();

            try
            {
                customerService.ValidateEmail("invalidEmail");
            }
            catch (Exceptions.InvalidDataException ex)
            {
                logger.LogError(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                inventoryService.ProcessOrder(60);
            }
            catch (InsufficientStockException ex)
            {
                logger.LogError(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                paymentService.ProcessPayment(100, false);
            }
            catch (PaymentFailedException ex)
            {
                logger.LogError(ex.Message);
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}
