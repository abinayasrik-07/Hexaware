using System;
using TechShop.Exceptions;

namespace TechShop.Repository
{
    public class IPaymentRepository
    {
        public void ProcessPayment(decimal amount, bool isPaymentSuccessful)
        {
            if (!isPaymentSuccessful)
                throw new PaymentFailedException("Payment was declined.");

            Console.WriteLine("Payment processed successfully.");
        }
    }
}
