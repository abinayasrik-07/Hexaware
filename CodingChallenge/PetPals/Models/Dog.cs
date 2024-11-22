using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models
{
    public class Dog : Pets
    {
        public string DogBreed { get; set; }
        public Dog(int petID, string name, int age, string breed, string type, bool availableForAdoption, int shelterID, string dogBreed)
            : base(petID, name, age, breed, type, availableForAdoption, shelterID)
        {
            DogBreed = dogBreed;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, DogBreed: {DogBreed}";
        }
    }
}
