using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Models
{
    public class Cat : Pets
    {
        public string CatColor { get; set; }

        public Cat(int petID, string name, int age, string breed, string type, bool availableForAdoption, int shelterID, string catColor)
            : base(petID, name, age, breed, type, availableForAdoption, shelterID)
        {
            CatColor = catColor;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, CatColor: {CatColor}";
        }
    }
}
