using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models
{
    public class Shelters
    {
        public int ShelterID { get; set; } 
        public string Name { get; set; }   
        public string Location { get; set; } 
        public Shelters(int shelterID, string name, string location)
        {
            ShelterID = shelterID;
            Name = name;
            Location = location;
        }

        public Shelters() 
        {
        
        }

        public override string ToString()
        {
            return $"Shelter ID: {ShelterID}, Name: {Name}, Location: {Location}";
        }
    }
}
