
using CarConnect.Exceptions;
using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly string _connectionString;

        public VehicleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Vehicles WHERE VehicleID = @VehicleID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VehicleID", vehicleId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Vehicle
                        {
                            VehicleID = (int)reader["VehicleID"],
                            Model = reader["Model"].ToString(),
                            Make = reader["Make"].ToString(),
                            Year = (int)reader["Year"],
                            Color = reader["Color"].ToString(),
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            Availability = (bool)reader["Availability"],
                            DailyRate = (double)reader["DailyRate"]
                        };
                    }
                }
            }
            throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} not found.");

        }

        public List<Vehicle> GetAvailableVehicles()
        {
            var vehicles = new List<Vehicle>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Vehicles WHERE Availability = 1";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehicles.Add(new Vehicle
                        {
                            VehicleID = (int)reader["VehicleID"],
                            Model = reader["Model"].ToString(),
                            Make = reader["Make"].ToString(),
                            Year = (int)reader["Year"],
                            Color = reader["Color"].ToString(),
                            RegistrationNumber = reader["RegistrationNumber"].ToString(),
                            Availability = (bool)reader["Availability"],
                            DailyRate = (double)reader["DailyRate"]
                        });
                    }
                }
            }
            return vehicles;
        }

        public void AddVehicle(Vehicle vehicleData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Vehicles (Model, Make, Year, Color, RegistrationNumber, Availability, DailyRate) " +
                            "VALUES (@Model, @Make, @Year, @Color, @RegistrationNumber, @Availability, @DailyRate)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Model", vehicleData.Model);
                command.Parameters.AddWithValue("@Make", vehicleData.Make);
                command.Parameters.AddWithValue("@Year", vehicleData.Year);
                command.Parameters.AddWithValue("@Color", vehicleData.Color);
                command.Parameters.AddWithValue("@RegistrationNumber", vehicleData.RegistrationNumber);
                command.Parameters.AddWithValue("@Availability", vehicleData.Availability);
                command.Parameters.AddWithValue("@DailyRate", vehicleData.DailyRate);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateVehicle(Vehicle vehicleData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Vehicles SET Model = @Model, Make = @Make, Year = @Year, Color = @Color, " +
                            "RegistrationNumber = @RegistrationNumber, Availability = @Availability, DailyRate = @DailyRate " +
                            "WHERE VehicleID = @VehicleID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Model", vehicleData.Model);
                command.Parameters.AddWithValue("@Make", vehicleData.Make);
                command.Parameters.AddWithValue("@Year", vehicleData.Year);
                command.Parameters.AddWithValue("@Color", vehicleData.Color);
                command.Parameters.AddWithValue("@RegistrationNumber", vehicleData.RegistrationNumber);
                command.Parameters.AddWithValue("@Availability", vehicleData.Availability);
                command.Parameters.AddWithValue("@DailyRate", vehicleData.DailyRate);
                command.Parameters.AddWithValue("@VehicleID", vehicleData.VehicleID);

                command.ExecuteNonQuery();
            }
        }

        public void RemoveVehicle(int vehicleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VehicleID", vehicleId);

                command.ExecuteNonQuery();
            }
        }
    }
}

