
using PetPals.Models;
using System;
using System.Data.SqlClient;

namespace PetPals.Models
{
    internal class CashDonation : Donations
    {
        private DateTime donationDate;

        public DateTime DonationDate
        {
            get { return donationDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Donation date cannot be in the future.");
                donationDate = value;
            }
        }

        public CashDonation(string donorName, decimal amount, DateTime donationDate)
            : base(donorName, amount)
        {
            DonationDate = donationDate;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Cash Donation Recorded: {this}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Donation Date: {DonationDate:yyyy-MM-dd}";
        }
    }
}


//namespace PetPals.Models
//{
//    public class CashDonation : Donations
//    {
//        public CashDonation(string donorName, decimal amount, DateTime donationDate, int shelterID)
//            : base(donorName, amount, "Cash", null, donationDate, shelterID)
//        {

//        }

//        public override void RecordDonation()
//        {
//            string connectionString = "Server=DESKTOP-SA5ENHD;Database=PetPals;Trusted_Connection=True;"; 
//            string query = "INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationDate, ShelterID) " +
//                           "VALUES (@DonorName, @DonationType, @DonationAmount, @DonationDate, @ShelterID)";

//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@DonorName", this.DonorName);
//                        command.Parameters.AddWithValue("@DonationType", this.DonationType);
//                        command.Parameters.AddWithValue("@DonationAmount", this.Amount);
//                        command.Parameters.AddWithValue("@DonationDate", this.DonationDate);
//                        command.Parameters.AddWithValue("@ShelterID", this.ShelterID);

//                        int rowsAffected = command.ExecuteNonQuery();

//                        if (rowsAffected > 0)
//                        {
//                            Console.WriteLine($"Cash Donation Recorded: {this.ToString()}");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Error: Unable to record the donation.");
//                        }
//                    }
//                }
//            }
//            catch (SqlException ex)
//            {
//                Console.WriteLine($"SQL Error: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//        }
//    }
//}
