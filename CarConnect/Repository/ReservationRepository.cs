using CarConnect.Exceptions;
using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly string _connectionString;

        public ReservationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Reservation GetReservationById(int reservationId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    var query = "SELECT * FROM Reservations WHERE ReservationID = @ReservationID";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ReservationID", reservationId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Reservation
                            {
                                ReservationID = (int)reader["ReservationID"],
                                CustomerID = (int)reader["CustomerID"],
                                VehicleID = (int)reader["VehicleID"],
                                StartDate = (DateTime)reader["StartDate"],
                                EndDate = (DateTime)reader["EndDate"],
                                TotalCost = (double)reader["TotalCost"],
                                Status = reader["Status"].ToString()
                            };
                        }
                        else
                        {
                            throw new ReservationException($"Reservation with ID {reservationId} not found.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Error connecting to the database.", ex);
            }
        }

        public List<Reservation> GetReservationsByCustomerId(int customerId)
        {
            var reservations = new List<Reservation>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Reservations WHERE CustomerID = @CustomerID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reservations.Add(new Reservation
                        {
                            ReservationID = (int)reader["ReservationID"],
                            CustomerID = (int)reader["CustomerID"],
                            VehicleID = (int)reader["VehicleID"],
                            StartDate = (DateTime)reader["StartDate"],
                            EndDate = (DateTime)reader["EndDate"],
                            TotalCost = (double)reader["TotalCost"],
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            return reservations;
        }

        public void CreateReservation(Reservation reservationData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Reservations (CustomerID, VehicleID, StartDate, EndDate, TotalCost, Status) " +
                            "VALUES (@CustomerID, @VehicleID, @StartDate, @EndDate, @TotalCost, @Status)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", reservationData.CustomerID);
                command.Parameters.AddWithValue("@VehicleID", reservationData.VehicleID);
                command.Parameters.AddWithValue("@StartDate", reservationData.StartDate);
                command.Parameters.AddWithValue("@EndDate", reservationData.EndDate);
                command.Parameters.AddWithValue("@TotalCost", reservationData.TotalCost);
                command.Parameters.AddWithValue("@Status", reservationData.Status);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateReservation(Reservation reservationData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Reservations SET CustomerID = @CustomerID, VehicleID = @VehicleID, StartDate = @StartDate, " +
                            "EndDate = @EndDate, TotalCost = @TotalCost, Status = @Status WHERE ReservationID = @ReservationID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", reservationData.CustomerID);
                command.Parameters.AddWithValue("@VehicleID", reservationData.VehicleID);
                command.Parameters.AddWithValue("@StartDate", reservationData.StartDate);
                command.Parameters.AddWithValue("@EndDate", reservationData.EndDate);
                command.Parameters.AddWithValue("@TotalCost", reservationData.TotalCost);
                command.Parameters.AddWithValue("@Status", reservationData.Status);
                command.Parameters.AddWithValue("@ReservationID", reservationData.ReservationID);

                command.ExecuteNonQuery();
            }
        }

        public void CancelReservation(int reservationId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Reservations WHERE ReservationID = @ReservationID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ReservationID", reservationId);

                command.ExecuteNonQuery();
            }
        }
    }
}

