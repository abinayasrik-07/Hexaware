using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetPals.Models
{
    public class PetShelter
    {
        public int ShelterID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Pets> AvailablePets { get; set; }

        public PetShelter(int shelterID, string name, string location)
        {
            ShelterID = shelterID;
            Name = name;
            Location = location;
            AvailablePets = new List<Pets>();
        }

        public void AddPet(Pets pet)
        {
            AvailablePets.Add(pet);
        }

        public void RemovePet(Pets pet)
        {
            AvailablePets.Remove(pet);
        }

        public void ListAvailablePets()
        {
            Console.WriteLine($"Pets available for adoption in {Name}:");
            foreach (var pet in AvailablePets)
            {
                Console.WriteLine(pet.ToString());
            }
        }
    }
}
