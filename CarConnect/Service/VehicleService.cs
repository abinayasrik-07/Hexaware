
using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using System.Collections.Generic;

namespace CarConnect.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            var vehicle = _vehicleRepository.GetVehicleById(vehicleId);
            if (vehicle == null)
            {
                throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} not found.");
            }
            return vehicle;
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            return _vehicleRepository.GetAvailableVehicles();
        }

        public void AddVehicle(Vehicle vehicleData)
        {
            _vehicleRepository.AddVehicle(vehicleData);
        }

        public void UpdateVehicle(Vehicle vehicleData)
        {
            _vehicleRepository.UpdateVehicle(vehicleData);
        }

        public void RemoveVehicle(int vehicleId)
        {
            _vehicleRepository.RemoveVehicle(vehicleId);
        }
    }
}

