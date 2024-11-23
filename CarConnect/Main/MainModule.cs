
using CarConnect.Service;
using CarConnect.Model;
using CarConnect.Repository;
using CarConnect.Utility;
using System;

namespace CarConnect.Main
{
    class MainModule
    {
        public void Run()
        {
            string connectionString = DbConnUtil.GetConnectionString();

            IAdminRepository adminRepository = new AdminRepository(connectionString);
            IAdminService adminService = new AdminService(adminRepository);

            ICustomerRepository customerRepository = new CustomerRepository(connectionString);
            ICustomerService customerService = new CustomerService(customerRepository);

            IVehicleRepository vehicleRepository = new VehicleRepository(connectionString);
            IVehicleService vehicleService = new VehicleService(vehicleRepository);

            IReservationRepository reservationRepository = new ReservationRepository(connectionString);
            IReservationService reservationService = new ReservationService(reservationRepository);

            int choice = -1;

            do
            {
                Console.WriteLine("\n-----Car Connect System-----");
                Console.WriteLine("1. Admin Operations");
                Console.WriteLine("2. Customer Operations");
                Console.WriteLine("3. Vehicle Operations");
                Console.WriteLine("4. Reservation Operations");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        HandleAdminOperations(adminService);
                        break;
                    case 2:
                        HandleCustomerOperations(customerService);
                        break;
                    case 3:
                        HandleVehicleOperations(vehicleService);
                        break;
                    case 4:
                        HandleReservationOperations(reservationService);
                        break;
                    case 5:
                        Console.WriteLine("Exit!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 0);


            static void HandleAdminOperations(IAdminService adminService)
            {
                Console.WriteLine("\n--- Admin Operations ---");
                Console.WriteLine("1. Get Admin by ID");
                Console.WriteLine("2. Register Admin");
                Console.WriteLine("3. Update Admin");
                Console.WriteLine("4. Delete Admin");
                Console.Write("Enter your choice: ");
                int adminChoice = int.Parse(Console.ReadLine());

                try
                {
                    switch (adminChoice)
                    {
                        case 1:
                            Console.Write("Enter Admin ID: ");
                            int adminId = int.Parse(Console.ReadLine());
                            var admin = adminService.GetAdminById(adminId);
                            Console.WriteLine($"Admin Details: {admin}");
                            break;

                        case 2:
                            Console.WriteLine("Enter Admin Details:");
                            Admin newAdmin = new Admin
                            {
                                FirstName = ReadString("First Name"),
                                LastName = ReadString("Last Name"),
                                Email = ReadString("Email"),
                                PhoneNumber = ReadString("Phone Number"),
                                Username = ReadString("Username"),
                                Password = ReadString("Password"),
                                Role = ReadString("Role"),
                                JoinDate = DateTime.Now
                            };
                            adminService.RegisterAdmin(newAdmin);
                            Console.WriteLine("Admin registered successfully.");
                            break;

                        case 3:
                            Console.Write("Enter Admin ID to update: ");
                            int updateAdminId = int.Parse(Console.ReadLine());
                            Admin updatedAdmin = adminService.GetAdminById(updateAdminId);

                            updatedAdmin.FirstName = ReadString("First Name", updatedAdmin.FirstName);
                            updatedAdmin.LastName = ReadString("Last Name", updatedAdmin.LastName);
                            updatedAdmin.Email = ReadString("Email", updatedAdmin.Email);
                            updatedAdmin.PhoneNumber = ReadString("Phone Number", updatedAdmin.PhoneNumber);
                            adminService.UpdateAdmin(updatedAdmin);
                            Console.WriteLine("Admin updated successfully.");
                            break;

                        case 4:
                            Console.Write("Enter Admin ID to delete: ");
                            int deleteAdminId = int.Parse(Console.ReadLine());
                            adminService.DeleteAdmin(deleteAdminId);
                            Console.WriteLine("Admin deleted successfully.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static void HandleCustomerOperations(ICustomerService customerService)
            {
                Console.WriteLine("\n--- Customer Operations ---");
                Console.WriteLine("1. Get Customer by ID");
                Console.WriteLine("2. Register Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.Write("Enter your choice: ");
                int customerChoice = int.Parse(Console.ReadLine());

                try
                {
                    switch (customerChoice)
                    {
                        case 1:
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            var customer = customerService.GetCustomerById(customerId);
                            Console.WriteLine($"Customer Details: {customer}");
                            break;

                        case 2:
                            Console.WriteLine("Enter Customer Details:");
                            Customer newCustomer = new Customer
                            {
                                FirstName = ReadString("First Name"),
                                LastName = ReadString("Last Name"),
                                Email = ReadString("Email"),
                                PhoneNumber = ReadString("Phone Number"),
                                Username = ReadString("Username"),
                                Password = ReadString("Password"),
                                Address = ReadString("Address"),
                                RegistrationDate = DateTime.Now
                            };
                            customerService.RegisterCustomer(newCustomer);
                            Console.WriteLine("Customer registered successfully.");
                            break;

                        case 3:
                            Console.Write("Enter Customer ID to update: ");
                            int updateCustomerId = int.Parse(Console.ReadLine());
                            Customer updatedCustomer = customerService.GetCustomerById(updateCustomerId);

                            updatedCustomer.FirstName = ReadString("First Name", updatedCustomer.FirstName);
                            updatedCustomer.LastName = ReadString("Last Name", updatedCustomer.LastName);
                            updatedCustomer.Email = ReadString("Email", updatedCustomer.Email);
                            updatedCustomer.PhoneNumber = ReadString("Phone Number", updatedCustomer.PhoneNumber);
                            customerService.UpdateCustomer(updatedCustomer);
                            Console.WriteLine("Customer updated successfully.");
                            break;

                        case 4:
                            Console.Write("Enter Customer ID to delete: ");
                            int deleteCustomerId = int.Parse(Console.ReadLine());
                            customerService.DeleteCustomer(deleteCustomerId);
                            Console.WriteLine("Customer deleted successfully.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static void HandleVehicleOperations(IVehicleService vehicleService)
            {
                Console.WriteLine("\n--- Vehicle Operations ---");
                Console.WriteLine("1. Get Vehicle by ID");
                Console.WriteLine("2. Add Vehicle");
                Console.WriteLine("3. Update Vehicle");
                Console.WriteLine("4. Remove Vehicle");
                Console.WriteLine("5. Get Available Vehicles");
                Console.Write("Enter your choice: ");
                int vehicleChoice = int.Parse(Console.ReadLine());

                try
                {
                    switch (vehicleChoice)
                    {
                        case 1:
                            Console.Write("Enter Vehicle ID: ");
                            int vehicleId = int.Parse(Console.ReadLine());
                            var vehicle = vehicleService.GetVehicleById(vehicleId);
                            if (vehicle != null)
                            {
                                Console.WriteLine($"Vehicle Details: {vehicle}");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Enter Vehicle Details:");
                            Vehicle newVehicle = new Vehicle
                            {
                                Model = ReadString("Model"),
                                Make = ReadString("Make"),
                                Year = int.Parse(ReadString("Year")),
                                Color = ReadString("Color"),
                                RegistrationNumber = ReadString("Registration Number"),
                                Availability = bool.Parse(ReadString("Availability (true/false)")),
                                DailyRate = double.Parse(ReadString("Daily Rate"))
                            };
                            vehicleService.AddVehicle(newVehicle);
                            Console.WriteLine("Vehicle added successfully.");
                            break;

                        case 3:
                            Console.Write("Enter Vehicle ID to update: ");
                            int updateVehicleId = int.Parse(Console.ReadLine());
                            var existingVehicle = vehicleService.GetVehicleById(updateVehicleId);

                            if (existingVehicle != null)
                            {
                                existingVehicle.Model = ReadString("Model", existingVehicle.Model);
                                existingVehicle.Make = ReadString("Make", existingVehicle.Make);
                                existingVehicle.Year = int.Parse(ReadString("Year", existingVehicle.Year.ToString()));
                                existingVehicle.Color = ReadString("Color", existingVehicle.Color);
                                existingVehicle.RegistrationNumber = ReadString("Registration Number", existingVehicle.RegistrationNumber);
                                existingVehicle.Availability = bool.Parse(ReadString("Availability (true/false)", existingVehicle.Availability.ToString()));
                                existingVehicle.DailyRate = double.Parse(ReadString("Daily Rate", existingVehicle.DailyRate.ToString()));

                                vehicleService.UpdateVehicle(existingVehicle);
                                Console.WriteLine("Vehicle updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Vehicle not found.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Vehicle ID to remove: ");
                            int removeVehicleId = int.Parse(Console.ReadLine());
                            vehicleService.RemoveVehicle(removeVehicleId);
                            Console.WriteLine("Vehicle removed successfully.");
                            break;

                        case 5:
                            Console.WriteLine("Available Vehicles:");
                            var availableVehicles = vehicleService.GetAvailableVehicles();
                            foreach (var availableVehicle in availableVehicles)
                            {
                                Console.WriteLine(availableVehicle);
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static void HandleReservationOperations(IReservationService reservationService)
            {
                Console.WriteLine("\n--- Reservation Operations ---");
                Console.WriteLine("1. Get Reservation by ID");
                Console.WriteLine("2. Create Reservation");
                Console.WriteLine("3. Update Reservation");
                Console.WriteLine("4. Cancel Reservation");
                Console.WriteLine("5. Get Reservations by Customer ID");
                Console.Write("Enter your choice: ");
                int reservationChoice = int.Parse(Console.ReadLine());

                try
                {
                    switch (reservationChoice)
                    {
                        case 1:
                            Console.Write("Enter Reservation ID: ");
                            int reservationId = int.Parse(Console.ReadLine());
                            var reservation = reservationService.GetReservationById(reservationId);
                            if (reservation != null)
                            {
                                Console.WriteLine($"Reservation Details: {reservation}");
                            }
                            else
                            {
                                Console.WriteLine("Reservation not found.");
                            }
                            break;

                        case 2:
                        //    Console.WriteLine("Enter Reservation Details:");
                        //    Reservation newReservation = new Reservation
                        //    {
                        //        CustomerID = int.Parse(ReadString("Customer ID")),
                        //        VehicleID = int.Parse(ReadString("Vehicle ID")),
                        //        StartDate = DateTime.Parse(ReadString("Start Date (yyyy-mm-dd)")),
                        //        EndDate = DateTime.Parse(ReadString("End Date (yyyy-mm-dd)")),
                        //        Status = ReadString("Status (e.g., Confirmed, Cancelled)")
                        //    };
                        //    newReservation.TotalCost = reservationService.CalculateTotalCost(newReservation.VehicleID, newReservation.StartDate, newReservation.EndDate);
                        //    reservationService.CreateReservation(newReservation);
                            Console.WriteLine("Reservation created successfully.");
                            break;

                        case 3:
                            Console.Write("Enter Reservation ID to update: ");
                            int updateReservationId = int.Parse(Console.ReadLine());
                            var existingReservation = reservationService.GetReservationById(updateReservationId);

                            if (existingReservation != null)
                            {
                                existingReservation.StartDate = DateTime.Parse(ReadString("Start Date (yyyy-mm-dd)", existingReservation.StartDate.ToString("yyyy-MM-dd")));
                                existingReservation.EndDate = DateTime.Parse(ReadString("End Date (yyyy-mm-dd)", existingReservation.EndDate.ToString("yyyy-MM-dd")));
                                existingReservation.Status = ReadString("Status", existingReservation.Status);
                                //existingReservation.TotalCost = reservationService.CalculateTotalCost(existingReservation.VehicleID, existingReservation.StartDate, existingReservation.EndDate);

                                reservationService.UpdateReservation(existingReservation);
                                Console.WriteLine("Reservation updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Reservation not found.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Reservation ID to cancel: ");
                            int cancelReservationId = int.Parse(Console.ReadLine());
                            reservationService.CancelReservation(cancelReservationId);
                            Console.WriteLine("Reservation cancelled successfully.");
                            break;

                        case 5:
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            var customerReservations = reservationService.GetReservationsByCustomerId(customerId);
                            if (customerReservations != null && customerReservations.Any())
                            {
                                Console.WriteLine("Reservations:");
                                foreach (var res in customerReservations)
                                {
                                    Console.WriteLine(res);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No reservations found for the given Customer ID.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static string ReadString(string fieldName, string defaultValue = "")
            {
                Console.Write($"{fieldName} [{defaultValue}]: ");
                string input = Console.ReadLine();
                return string.IsNullOrEmpty(input) ? defaultValue : input;
            }


        }
    }
}


