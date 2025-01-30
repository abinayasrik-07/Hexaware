using System;

namespace Tasks.Inheritance
{
    public class Chair : Furniture
    {
        public bool HasArmrest;

        public Chair(string material, string color, decimal price, bool hasArmrest) : base(material, color, price)
        {
            HasArmrest = hasArmrest;
        }

        public void DisplayChairDetails()
        {
            DisplayDetails();
            Console.WriteLine($"Has Armrest: {(HasArmrest ? "Yes" : "No")}");
        }
    }
}
