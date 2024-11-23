using CarConnect.Model;
using System.Collections.Generic;

namespace CarConnect.Service
{
    public interface IReservationService
    {
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetReservationsByCustomerId(int customerId);
        void CreateReservation(Reservation reservationData);
        void UpdateReservation(Reservation reservationData);
        void CancelReservation(int reservationId);
        //double CalculateTotalCost(int vehicleID, DateTime startDate, DateTime endDate);
    }
}
