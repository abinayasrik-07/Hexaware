
namespace PetPals.Models
{
    public abstract class Donations
    {
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public string DonationType { get; set; }
        public string DonationItem { get; set; }
        public DateTime DonationDate { get; set; }
        public int ShelterID { get; set; } 
        public Donations(string donorName, decimal amount, string donationType, string donationItem, DateTime donationDate, int shelterID)
        {
            DonorName = donorName;
            Amount = amount;
            DonationType = donationType;
            DonationItem = donationItem;
            DonationDate = donationDate;
            ShelterID = shelterID;
        }

        protected Donations(string donorName, decimal amount)
        {
            DonorName = donorName;
            Amount = amount;
        }

        public abstract void RecordDonation();
    }
}
