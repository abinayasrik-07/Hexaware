
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
