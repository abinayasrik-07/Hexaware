using System;

namespace Tasks.Inheritance
{
    public class Furniture
    {
        public string Material;
        public string Color;
        public decimal Price;

        public Furniture(string material, string color, decimal price)
        {
            Material = material;
            Color = color;
            Price = price;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Material: {Material}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Price: {Price:C}");
        }
    }
}
