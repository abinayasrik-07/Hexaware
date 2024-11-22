using PetPals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetPals.Services;

namespace PetPals.Repository
{
    internal interface IPetRepository
    {
        void AddPet(Pets pet);
        void RemovePet(Pets pet);
        List <Pets> GetAvailablePet();
    }
}
