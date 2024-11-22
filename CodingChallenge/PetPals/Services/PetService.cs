using PetPals.Models;
using PetPals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Services
{
    public class PetService
    {
        private readonly PetRepository _petRepository;

        public PetService(PetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void AddPet(Pets pet)
        {
            if (pet.Age <= 0)
                throw new ArgumentException("Pet age must be a positive integer.");

            _petRepository.InsertPet(pet);
            Console.WriteLine($"Pet '{pet.Name}' has been added.");
        }

        public void RemovePet(int petId)
        {
            _petRepository.DeletePet(petId);
            Console.WriteLine($"Pet with ID {petId} has been removed.");
        }

        public List<Pets> GetAvailablePets()
        {
            var pets = _petRepository.GetAllAvailablePets();
            if (pets.Count == 0)
                Console.WriteLine("No pets available for adoption.");
            return pets;
        }
    }
}
