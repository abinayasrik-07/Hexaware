using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Models;

namespace PetPals.Repository
{
    public class ShelterRepository
    {
        private readonly string _connectionString;

        public ShelterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsertShelter(Shelters shelter)
        {
            string query = "INSERT INTO Shelters (Name, Location) VALUES (@Name, @Location)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", shelter.Name);
                command.Parameters.AddWithValue("@Location", shelter.Location);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Shelters> GetAllShelters()
        {
            var shelters = new List<Shelters>();
            string query = "SELECT * FROM Shelters";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        shelters.Add(new Shelters
                        {
                            ShelterID = Convert.ToInt32(reader["ShelterID"]),
                            Name = reader["Name"].ToString(),
                            Location = reader["Location"].ToString()
                        });
                    }
                }
            }
            return shelters;
        }
    }
}
