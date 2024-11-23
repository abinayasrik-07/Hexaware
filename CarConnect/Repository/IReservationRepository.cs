using CarConnect.Model;
using System.Collections.Generic;

namespace CarConnect.Repository
{
    public interface IReservationRepository
    {
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetReservationsByCustomerId(int customerId);
        void CreateReservation(Reservation reservationData);
        void UpdateReservation(Reservation reservationData);
        void CancelReservation(int reservationId);
    }
}

