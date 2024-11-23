
using CarConnect.Model;
using System.Collections.Generic;

namespace CarConnect.Repository
{
    public interface IVehicleRepository
    {
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetAvailableVehicles();
        void AddVehicle(Vehicle vehicleData);
        void UpdateVehicle(Vehicle vehicleData);
        void RemoveVehicle(int vehicleId);
    }
}
