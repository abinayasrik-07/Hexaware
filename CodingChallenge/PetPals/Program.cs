using System;
using System.Collections.Generic;
using PetPals.Repository;
using PetPals.Services;
using PetPals.Models; // Assuming all the classes are in this namespace
using System.Data.SqlClient;

namespace PetPals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simulate user interaction and call methods for different features

            // 1. Create Pets and Shelters
            Shelters shelter1 = new Shelters(1, "Happy Tails Shelter", "Chennai, India");
            Shelters shelter2 = new Shelters(2, "Paws and Claws Shelter", "Bangalore, India");

            Pets dog = new Dog("Buddy", 3, "Golden Retriever", "Golden Retriever", shelter1);
            Pets cat = new Cat("Mittens", 2, "Siamese", "White", shelter2);

            // Add pets to shelters
            shelter1.AddPet(dog);
            shelter2.AddPet(cat);

            // Display pets available for adoption
            shelter1.ListAvailablePets();
            shelter2.ListAvailablePets();

            // 2. Handle Donations (Cash Donation)
            CashDonation cashDonation = new CashDonation("John Doe", 500.00m, DateTime.Now, 1);
            cashDonation.RecordDonation(); // This inserts the donation into the database

            // 3. Handle Item Donations
            ItemDonation itemDonation = new ItemDonation("Jane Smith", 0, "Food", DateTime.Now, 2);
            itemDonation.RecordDonation(); // This records an item donation

            // 4. Create and Manage Adoption Events
            AdoptionEvent event1 = new AdoptionEvent(1, "Pet Adoption Drive", DateTime.Now, "Chennai, India", shelter1);
            event1.HostEvent();
            event1.RegisterParticipant(shelter1); // Shelter participates in the event

            // 5. User Input for Pet Age (with Exception Handling)
            Console.WriteLine("Enter pet age (positive integer): ");
            try
            {
                int petAge = int.Parse(Console.ReadLine());
                if (petAge <= 0) throw new ArgumentException("Age must be a positive number.");
                Console.WriteLine($"You entered a valid pet age: {petAge}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Age must be a valid number.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 6. Demonstrate Insufficient Funds Exception
            Console.WriteLine("Enter donation amount (minimum $10): ");
            try
            {
                decimal donationAmount = decimal.Parse(Console.ReadLine());
                if (donationAmount < 10) throw new InsufficientFundsException("Donation must be at least $10.");
                Console.WriteLine($"Donation of ${donationAmount} received.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid amount! Please enter a valid number.");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 7. Demonstrate File Handling Exception (Simulate reading a file)
            try
            {
                string filePath = "donations.txt"; // Simulate file path
                string fileContent = System.IO.File.ReadAllText(filePath); // This would throw an exception if the file doesn't exist
                Console.WriteLine("File content: " + fileContent);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }

            // 8. Custom AdoptionException
            try
            {
                Pet unavailablePet = null;
                if (unavailablePet == null)
                {
                    throw new AdoptionException("Pet is not available for adoption.");
                }
            }
            catch (AdoptionException ex)
            {
                Console.WriteLine($"Adoption Error: {ex.Message}");
            }
        }
    }

    // Custom Exception for Insufficient Funds
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    // Custom AdoptionException
    public class AdoptionException : Exception
    {
        public AdoptionException(string message) : base(message) { }
    }
}

