using System;

namespace Tasks.Inheritance
{
    public class Bookshelf : Furniture
    {
        public int NumberOfShelves;

        public Bookshelf(string material, string color, decimal price, int numberOfShelves) : base(material, color, price)
        {
            NumberOfShelves = numberOfShelves;
        }

        public void DisplayBookshelfDetails()
        {
            DisplayDetails();
            Console.WriteLine($"Number of Shelves: {NumberOfShelves}");
        }
    }
}
