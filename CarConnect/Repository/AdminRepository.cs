
using CarConnect.Exceptions;
using CarConnect.Model;
using System;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Admin GetAdminById(int adminId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Admins WHERE AdminID = @AdminID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminID", adminId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin
                        {
                            AdminID = (int)reader["AdminID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            JoinDate = (DateTime)reader["JoinDate"]
                        };
                    }
                }
            }
            throw new AdminNotFoundException($"Admin with ID {adminId} not found.");
        }

        public Admin GetAdminByUsername(string username)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Admins WHERE Username = @Username";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Admin
                        {
                            AdminID = (int)reader["AdminID"],
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            JoinDate = (DateTime)reader["JoinDate"]
                        };
                    }
                }
            }
            return null;
        }

        public void RegisterAdmin(Admin adminData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Admins (FirstName, LastName, Email, PhoneNumber, Username, Password, Role, JoinDate) " +
                            "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password, @Role, @JoinDate)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", adminData.FirstName);
                command.Parameters.AddWithValue("@LastName", adminData.LastName);
                command.Parameters.AddWithValue("@Email", adminData.Email);
                command.Parameters.AddWithValue("@PhoneNumber", adminData.PhoneNumber);
                command.Parameters.AddWithValue("@Username", adminData.Username);
                command.Parameters.AddWithValue("@Password", adminData.Password);
                command.Parameters.AddWithValue("@Role", adminData.Role);
                command.Parameters.AddWithValue("@JoinDate", adminData.JoinDate);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateAdmin(Admin adminData)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Admins SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, " +
                            "Username = @Username, Password = @Password, Role = @Role, JoinDate = @JoinDate WHERE AdminID = @AdminID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", adminData.FirstName);
                command.Parameters.AddWithValue("@LastName", adminData.LastName);
                command.Parameters.AddWithValue("@Email", adminData.Email);
                command.Parameters.AddWithValue("@PhoneNumber", adminData.PhoneNumber);
                command.Parameters.AddWithValue("@Username", adminData.Username);
                command.Parameters.AddWithValue("@Password", adminData.Password);
                command.Parameters.AddWithValue("@Role", adminData.Role);
                command.Parameters.AddWithValue("@JoinDate", adminData.JoinDate);
                command.Parameters.AddWithValue("@AdminID", adminData.AdminID);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteAdmin(int adminId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Admins WHERE AdminID = @AdminID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminID", adminId);

                command.ExecuteNonQuery();
            }
        }
    }
}

