using PetPals.Models;
using PetPals.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Repository
{
    internal class PetRepository : IPetRepository
    {
        SqlCommand cmd = null;
        string connectionString;

        public PetRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public object petID { get; private set; }

        public void AddPet(Pets pet)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Pets (Name, Age, Breed) VALUES (@Name, @Age, @Breed)";
                
                cmd.Parameters.AddWithValue("@Name", pet.Name);
                cmd.Parameters.AddWithValue("@Age", pet.Age);
                cmd.Parameters.AddWithValue("@Breed", pet.Breed);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pets> GetAvailablePet()
        {
            List<Pets> pets = new List<Pets>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT * FROM Pets WHERE AvailableForAdoption = 1";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pets.Add(new Pets(
                        reader["Name"].ToString(),
                        Convert.ToInt32(reader["Age"]),
                        reader["Breed"].ToString()
                    ));
                }
            }
            return pets;
        }
        public void RemovePet(Pets pet)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "DELETE FROM Pets WHERE PetID = @PetID";
                
                cmd.Parameters.AddWithValue("@PetID", petID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
