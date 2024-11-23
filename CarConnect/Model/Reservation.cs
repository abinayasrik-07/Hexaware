using System;

namespace CarConnect.Model
{
    public class Reservation
    {
        private int _reservationID;
        private int _customerID;
        private int _vehicleID;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _totalCost;
        private string _status;

        public Reservation() { }

        public Reservation(int reservationID, int customerID, int vehicleID, DateTime startDate, DateTime endDate, double totalCost, string status)
        {
            _reservationID = reservationID;
            _customerID = customerID;
            _vehicleID = vehicleID;
            _startDate = startDate;
            _endDate = endDate;
            _totalCost = totalCost;
            _status = status;
        }

        public int ReservationID { get => _reservationID; set => _reservationID = value; }
        public int CustomerID { get => _customerID; set => _customerID = value; }
        public int VehicleID { get => _vehicleID; set => _vehicleID = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public double TotalCost { get => _totalCost; set => _totalCost = value; }
        public string Status { get => _status; set => _status = value; }

        public void CalculateTotalCost(double dailyRate)
        {
            int days = (int)(EndDate - StartDate).TotalDays;
            _totalCost = days * dailyRate;
        }
    }
}



