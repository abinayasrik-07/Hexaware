using System;

namespace Tasks
{
    public class Bike
    {
        private string brand;
        private string model;
        private decimal price;

        public void AcceptBikeDetails()
        {
            Console.WriteLine("\nAccepting Bike Details");

            Console.Write("\nEnter Bike Brand: ");
            brand = Console.ReadLine();

            Console.Write("Enter Bike Model: ");
            model = Console.ReadLine();

            Console.Write("Enter Bike Price: ");
            price = decimal.Parse(Console.ReadLine());
        }

        public void DisplayBikeDetails()
        {
            Console.WriteLine("\nDisplaying Bike Details");
            Console.WriteLine($"Brand: {brand}\nModel: {model}\nPrice: Rs {price}");
        }
    }
}
