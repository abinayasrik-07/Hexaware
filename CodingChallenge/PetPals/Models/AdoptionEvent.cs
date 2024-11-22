using PetPals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models
{
    public class AdoptionEvent
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public int ShelterID { get; set; }
        public List<PetShelter> Participants { get; set; }

        public AdoptionEvent(int eventID, string eventName, DateTime eventDate, string eventLocation, int shelterID)
        {
            EventID = eventID;
            EventName = eventName;
            EventDate = eventDate;
            EventLocation = eventLocation;
            ShelterID = shelterID;
            Participants = new List<PetShelter>();
        }

        public void HostEvent()
        {
            Console.WriteLine($"Hosting Adoption Event: {EventName} on {EventDate} at {EventLocation}");
        }

        public void RegisterParticipant(PetShelter shelter)
        {
            Participants.Add(shelter);
            Console.WriteLine($"Shelter {shelter.Name} registered for the event.");
        }
    }
}
