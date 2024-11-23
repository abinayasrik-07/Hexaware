using System;

namespace CarConnect.Model
{
    public class Vehicle
    {
        private int _vehicleID;
        private string _model;
        private string _make;
        private int _year;
        private string _color;
        private string _registrationNumber;
        private bool _availability;
        private double _dailyRate;

        public Vehicle() { }

        public Vehicle(int vehicleID, string model, string make, int year, string color,
                       string registrationNumber, bool availability, double dailyRate)
        {
            _vehicleID = vehicleID;
            _model = model;
            _make = make;
            _year = year;
            _color = color;
            _registrationNumber = registrationNumber;
            _availability = availability;
            _dailyRate = dailyRate;
        }

        public int VehicleID { get => _vehicleID; set => _vehicleID = value; }
        public string Model { get => _model; set => _model = value; }
        public string Make { get => _make; set => _make = value; }
        public int Year { get => _year; set => _year = value; }
        public string Color { get => _color; set => _color = value; }
        public string RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }
        public bool Availability { get => _availability; set => _availability = value; }
        public double DailyRate { get => _dailyRate; set => _dailyRate = value; }
    }
}
