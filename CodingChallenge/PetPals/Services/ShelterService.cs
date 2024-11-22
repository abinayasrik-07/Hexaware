using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetPals.Repository;
using PetPals.Models;

namespace PetPals.Services
{
    public class ShelterService
    {
        private readonly ShelterRepository _shelterRepository;

        public ShelterService(ShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public void AddShelter(Shelters shelter)
        {
            _shelterRepository.InsertShelter(shelter);
            Console.WriteLine($"Shelter '{shelter.Name}' has been added.");
        }

        public List<Shelters> GetAllShelters()
        {
            var shelters = _shelterRepository.GetAllShelters();
            if (shelters.Count == 0)
                Console.WriteLine("No shelters found.");
            return shelters;
        }
    }
}
