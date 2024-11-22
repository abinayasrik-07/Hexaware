//using System;
//using System.Data.SqlClient;
//using PetPals.Utility;
//namespace PetPals
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            bool continueRunning = true;

//            while (continueRunning)
//            {
//                Console.WriteLine("PetPals System");
//                Console.WriteLine("1. Display All Pets");
//                Console.WriteLine("2. Add New Pet");
//                Console.WriteLine("3. Record a Donation");
//                Console.WriteLine("4. Host Adoption Event");
//                Console.WriteLine("5. Exit");
//                Console.Write("Choose an option: ");

//                string choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        DisplayAllPets();
//                        break;

//                    case "2":
//                        AddNewPet();
//                        break;

//                    case "3":
//                        RecordDonation();
//                        break;

//                    case "4":
//                        HostAdoptionEvent();
//                        break;

//                    case "5":
//                        continueRunning = false;
//                        Console.WriteLine("Exiting the system.");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }

//                Console.WriteLine();
//            }
//        }

//        private static void DisplayAllPets()
//        {
//            string connectionString = DbConnUtil.GetConnectionString("db.properties");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "SELECT * FROM Pets";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        using (SqlDataReader reader = command.ExecuteReader())
//                        {
//                            Console.WriteLine("Available Pets:");
//                            while (reader.Read())
//                            {
//                                Console.WriteLine($"ID: {reader["PetID"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Breed: {reader["Breed"]}");
//                            }
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                }
//            }
//        }

//        private static void AddNewPet()
//        {
//            Console.WriteLine("Enter Pet Details:");
//            Console.Write("Name: ");
//            string name = Console.ReadLine();

//            Console.Write("Age: ");
//            if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
//            {
//                Console.WriteLine("Invalid Age. Age must be a positive integer.");
//                return;
//            }

//            Console.Write("Breed: ");
//            string breed = Console.ReadLine();

//            string connectionString = DbConnUtil.GetConnectionString("db.properties");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "INSERT INTO Pets (Name, Age, Breed) VALUES (@Name, @Age, @Breed)";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Name", name);
//                        command.Parameters.AddWithValue("@Age", age);
//                        command.Parameters.AddWithValue("@Breed", breed);

//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine("Pet added successfully.");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Failed to add the pet.");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                }
//            }
//        }

//        private static void RecordDonation()
//        {
//            Console.WriteLine("Enter Donation Details:");
//            Console.Write("Donor Name: ");
//            string donorName = Console.ReadLine();

//            Console.Write("Donation Amount: ");
//            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount < 10)
//            {
//                Console.WriteLine("Invalid Amount. Donation must be at least $10.");
//                return;
//            }

//            Console.Write("Donation Type (Cash/Item): ");
//            string donationType = Console.ReadLine();

//            string connectionString = DbConnUtil.GetConnectionString("db.properties");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = donationType.ToLower() == "cash"
//                        ? "INSERT INTO Donations (DonorName, Amount, DonationType) VALUES (@DonorName, @Amount, 'Cash')"
//                        : "INSERT INTO Donations (DonorName, Amount, DonationType) VALUES (@DonorName, @Amount, 'Item')";

//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@DonorName", donorName);
//                        command.Parameters.AddWithValue("@Amount", amount);

//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine("Donation recorded successfully.");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Failed to record the donation.");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                }
//            }
//        }

//        private static void HostAdoptionEvent()
//        {
//            Console.WriteLine("Hosting an Adoption Event...");

//            string connectionString = DbConnUtil.GetConnectionString("db.properties");
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "INSERT INTO AdoptionEvents (EventDate) VALUES (@EventDate)";
//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@EventDate", DateTime.Now);

//                        int rowsAffected = command.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine("Adoption event hosted successfully.");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Failed to host the adoption event.");
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                }
//            }
//        }
//    }
//}


using PetPals.Models;
using PetPals.Repository;
using System;
using System.Collections.Generic;

namespace PetPals
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();

            bool continueProgram = true;
            while (continueProgram)
            {
                Console.WriteLine("\n========== Pet Management System ==========");
                Console.WriteLine("1. Add Pet");
                Console.WriteLine("2. List Available Pets for Adoption");
                Console.WriteLine("3. Remove Pet");
                Console.WriteLine("4. Exit");
                Console.WriteLine("===========================================");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPet(petRepository);
                        break;

                    case "2":
                        ListAvailablePets(petRepository);
                        break;

                    case "3":
                       RemovePet(petRepository);
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program...");
                        continueProgram = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        // Method to add a new pet
        private static void AddPet(IPetRepository petRepository)
        {
            Console.WriteLine("\nEnter Pet Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Breed: ");
            string breed = Console.ReadLine();

            // Create a new pet instance
            Pets newPet = new Pets(name, age, breed);

            // Add pet to repository
            petRepository.AddPet(newPet);
            Console.WriteLine($"Pet '{name}' has been added successfully.");
        }

        // Method to list available pets for adoption
        private static void ListAvailablePets(IPetRepository petRepository)
        {
            Console.WriteLine("\nAvailable Pets for Adoption:");

            // Fetch available pets from repository
            List<Pets> availablePets = petRepository.GetAvailablePet();

            if (availablePets.Count > 0)
            {
                foreach (var pet in availablePets)
                {
                    Console.WriteLine($"- Name: {pet.Name}, Age: {pet.Age}, Breed: {pet.Breed}");
                }
            }
            else
            {
                Console.WriteLine("No pets are currently available for adoption.");
            }
        }

        // Method to remove a pet
        //private static void RemovePet(IPetRepository petRepository)
        //{
        //    Console.Write("\nEnter the ID of the Pet to remove: ");
        //    int petID = int.Parse(Console.ReadLine());

        //    // Create a temporary pet instance with the provided ID (other details aren't required)
        //    Pets petToRemove = new Pets { PetID = petID };

        //    // Remove the pet from repository
        //    petRepository.RemovePet(petToRemove);
        //    Console.WriteLine($"Pet with ID {petID} has been removed successfully.");
        //}

        private static void RemovePet(IPetRepository petRepository)
        {
            Console.Write("\nEnter the Name of the Pet to remove: ");
            string petName = Console.ReadLine();
            Console.Write("Enter the Breed of the Pet to remove: ");
            string petBreed = Console.ReadLine();

            // Fetch available pets and match by Name and Breed
            List<Pets> availablePets = petRepository.GetAvailablePet();
            Pets petToRemove = availablePets.FirstOrDefault(p => p.Name == petName && p.Breed == petBreed);

            if (petToRemove != null)
            {
                petRepository.RemovePet(petToRemove);
                Console.WriteLine($"Pet '{petName}' of breed '{petBreed}' has been removed successfully.");
            }
            else
            {
                Console.WriteLine($"No pet found with Name '{petName}' and Breed '{petBreed}'.");
            }
        }

    }
}



