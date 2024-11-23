using CarConnect.Model;
using CarConnect.Exceptions;
using CarConnect.Repository;
using System.Collections.Generic;

namespace CarConnect.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation GetReservationById(int reservationId)
        {
            var reservation = _reservationRepository.GetReservationById(reservationId);
            if (reservation == null)
            {
                throw new ReservationException($"Reservation with ID {reservationId} not found.");
            }
            return reservation;
        }

        public List<Reservation> GetReservationsByCustomerId(int customerId)
        {
            return _reservationRepository.GetReservationsByCustomerId(customerId);
        }

        public void CreateReservation(Reservation reservationData)
        {
            _reservationRepository.CreateReservation(reservationData);
        }

        public void UpdateReservation(Reservation reservationData)
        {
            _reservationRepository.UpdateReservation(reservationData);
        }

        public void CancelReservation(int reservationId)
        {
            _reservationRepository.CancelReservation(reservationId);
        }
    }
}
