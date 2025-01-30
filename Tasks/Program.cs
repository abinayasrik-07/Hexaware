using System;
using Tasks.Inheritance;

namespace Tasks
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region Orders
            //Orders

            List<Orders> orders = new List<Orders>
            {
                new Orders(101, "Shipped"),
                new Orders(102, "Processing"),
                new Orders(103, "Delivered"),
                new Orders(104, "Cancelled")
            };

            Console.WriteLine("\nEnter your order number to check the status: ");
            int orderNumber = int.Parse(Console.ReadLine());
            bool orderFound = false;
            foreach (Orders order in orders)
            {
                if (order.GetOrderNumber() == orderNumber)
                {
                    Console.WriteLine($"Order Number: {order.GetOrderNumber()}\nStatus: {order.GetStatus()}");
                    orderFound = true;
                    break;
                }
            }

            if (!orderFound)
            {
                Console.WriteLine("Order not found. Please check your order number.");
            }
            #endregion


            #region Bike
            //Bike

            Bike myBike = new Bike();
            myBike.AcceptBikeDetails();
            myBike.DisplayBikeDetails();
            #endregion


            #region Employee & Manager
            //Employee & Manager

            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Alice";
            emp.Salary = 50000;
            emp.Dob = new DateTime(1990, 5, 24);
            Console.WriteLine("\nEmployee Details:");
            emp.DisplayDetails();

            Manager mgr = new Manager();
            mgr.Id = 2;
            mgr.Name = "Bob";
            mgr.Salary = 70000;
            mgr.Dob = new DateTime(1985, 8, 15);
            mgr.OnsiteAllowance = 10000;
            mgr.Bonus = 5000;
            Console.WriteLine("\nManager Details:");
            mgr.DisplayDetails();
            #endregion


            #region TimePeriod
            // Time Period

            Console.Write("\nTime Period");
            TimePeriod timePeriod = new TimePeriod();
            Console.Write("\nEnter time in hours: ");
            double userHours = Convert.ToDouble(Console.ReadLine());
            timePeriod.Hours = userHours;
            timePeriod.DisplayTimeInSeconds();
            #endregion


            #region Count Function
            //Count Function

            Console.Write("\nCount Function");
            Console.Write("\nEnter the number of times to call CountFunction: ");
            int numCalls = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numCalls; i++)
            {
                CountFunc.CountFunction();
            }
            #endregion


            #region Furniture, BookShelf, Chair
            //Furniture, BookShelf, Chair

            Console.WriteLine("\nBookshelf Details:");
            Bookshelf bookshelf = new Bookshelf("Wood", "Brown", 5000, 5);
            bookshelf.DisplayBookshelfDetails();

            Console.WriteLine("\nChair Details:");
            Chair chair = new Chair("Metal", "Black", 1500, true);
            chair.DisplayChairDetails();
            #endregion
        }
    }

    #region Customer Discount Eligibility
    //    //1.You need to create a program that checks if a customer is eligible for a special discount
    //    //based on their loyalty points and total purchases.
    //    //The eligibility criteria are:
    //    //Loyalty points must be above 100.
    //    //Total purchases must be at least Rs1,000.

    //internal class CustomerDiscountEligibility
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Customer Discount Eligibility\n");
    //        Console.WriteLine("Enter loyalty points: ");
    //        int loyaltypoints = int.Parse(Console.ReadLine());

    //        Console.WriteLine("Enter total purchases: ");
    //        decimal totalpurchases = decimal.Parse(Console.ReadLine());

    //        if (loyaltypoints > 100 && totalpurchases >= 1000)
    //        {
    //            Console.WriteLine("Eligible for a special discount!");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Not eligible for a special discount.");
    //        }
    //    }
    //}
    #endregion

    #region Electronics Gadget Purchase
    //    //2. Create a program that simulates an electronics gadget purchase.
    //    //Display options such as "Check Available Stock," "Buy Product," "Return Product."
    //    //Ask the user to enter the current stock, and for "Buy Product,"
    //    //prompt them to enter the quantity they want to buy.
    //    //Ensure that the quantity to buy is not greater than the available stock and that it is at least 1 unit.
    //    //Display appropriate messages for success or failure.


    //    public class ElectronicsGadgetPurchase
    //    {
    //        public static void Main(string[] args)
    //        {
    //            Console.Write("Enter the current stock of the product: ");
    //            int stock = int.Parse(Console.ReadLine());

    //            bool exit = false;
    //            while (!exit)
    //            {
    //                Console.WriteLine("\nOptions:\n1. Check Available Stock\n2. Buy Product\n3. Return Product\n4. Exit");
    //                Console.Write("Options: ");
    //                int choice = int.Parse(Console.ReadLine());

    //                switch (choice)
    //                {
    //                    case 1:
    //                        Console.WriteLine($"Available stock: {stock}");
    //                        break;

    //                    case 2:
    //                        Console.Write("Enter quantity to buy: ");
    //                        int quantityToBuy = int.Parse(Console.ReadLine());

    //                        if (quantityToBuy < 1)
    //                        {
    //                            Console.WriteLine("Purchase quantity must be at least 1.");
    //                        }
    //                        else if (quantityToBuy > stock)
    //                        {
    //                            Console.WriteLine("Insufficient stock available.");
    //                        }
    //                        else
    //                        {
    //                            stock -= quantityToBuy;
    //                            Console.WriteLine($"Purchase successful! {quantityToBuy} units bought. Remaining stock: {stock}");
    //                        }
    //                        break;

    //                    case 3:
    //                        Console.Write("Enter quantity to return: ");
    //                        int quantityToReturn = int.Parse(Console.ReadLine());

    //                        if (quantityToReturn < 1)
    //                        {
    //                            Console.WriteLine("Return quantity must be at least 1.");
    //                        }
    //                        else
    //                        {
    //                            stock += quantityToReturn;
    //                            Console.WriteLine($"Return successful! {quantityToReturn} units returned. Current stock: {stock}");
    //                        }
    //                        break;

    //                    case 4:
    //                        exit = true;
    //                        Console.WriteLine("Exiting the program.");
    //                        break;

    //                    default:
    //                        Console.WriteLine("Invalid choice. Please try again.");
    //                        break;
    //                }
    //            }

    //        }
    //    }
    #endregion


}

