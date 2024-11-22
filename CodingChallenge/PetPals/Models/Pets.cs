
using PetPals.Models;

namespace PetPals.Models
{
    public class Pets
    {
        public int PetID { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; } 
        public string Breed { get; set; } 
        public string Type { get; set; } 
        public bool AvailableForAdoption { get; set; } 
        public int ShelterID { get; set; } 

        public Shelters Shelter { get; set; } 
        public Pets(int petID, string name, int age, string breed, string type, bool availableForAdoption, int shelterID)
        {
            PetID = petID;
            Name = name;
            Age = age;
            Breed = breed;
            Type = type;
            AvailableForAdoption = availableForAdoption;
            ShelterID = shelterID;
        }

        public Pets(string? v1, int v2, string? v3)
        {
        }

        public override string ToString()
        {
            return $"Pet ID: {PetID}, Name: {Name}, Age: {Age}, Breed: {Breed}, Type: {Type}, Available: {AvailableForAdoption}, Shelter ID: {ShelterID}";
        }
    }
}
