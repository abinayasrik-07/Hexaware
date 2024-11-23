using System;
using System.Data.SqlClient;
using CarConnect.Model;

namespace CarConnect.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer GetCustomerById(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            RegistrationDate = (DateTime)reader["RegistrationDate"]
                        };
                    }
                }
            }
            return null;
        }

        public Customer GetCustomerByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Customers WHERE Username = @Username";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerID = (int)reader["CustomerID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Address = reader["Address"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            RegistrationDate = (DateTime)reader["RegistrationDate"]
                        };
                    }
                }
            }
            return null;
        }

        public void RegisterCustomer(Customer customerData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Customers (FirstName, LastName, Email, PhoneNumber, Address, Username, Password, RegistrationDate) " +
                            "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @Username, @Password, @RegistrationDate)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", customerData.FirstName);
                command.Parameters.AddWithValue("@LastName", customerData.LastName);
                command.Parameters.AddWithValue("@Email", customerData.Email);
                command.Parameters.AddWithValue("@PhoneNumber", customerData.PhoneNumber);
                command.Parameters.AddWithValue("@Address", customerData.Address);
                command.Parameters.AddWithValue("@Username", customerData.Username);
                command.Parameters.AddWithValue("@Password", customerData.Password);
                command.Parameters.AddWithValue("@RegistrationDate", customerData.RegistrationDate);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customerData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, " +
                            "PhoneNumber = @PhoneNumber, Address = @Address, Password = @Password WHERE CustomerID = @CustomerID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", customerData.FirstName);
                command.Parameters.AddWithValue("@LastName", customerData.LastName);
                command.Parameters.AddWithValue("@Email", customerData.Email);
                command.Parameters.AddWithValue("@PhoneNumber", customerData.PhoneNumber);
                command.Parameters.AddWithValue("@Address", customerData.Address);
                command.Parameters.AddWithValue("@Password", customerData.Password);
                command.Parameters.AddWithValue("@CustomerID", customerData.CustomerID);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                command.ExecuteNonQuery();
            }
        }
    }
}

