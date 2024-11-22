using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models
{
    public class ItemDonation : Donations
    {
        public string ItemType { get; set; }

        public ItemDonation(string donorName, string itemType) : base(donorName, 0)
        {
            ItemType = itemType;
        }

        public override void RecordDonation() => Console.WriteLine($"Recorded item donation of {ItemType} from {DonorName}.");
    }
}
