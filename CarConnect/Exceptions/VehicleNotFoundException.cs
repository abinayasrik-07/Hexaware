using System;

namespace CarConnect.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(string message) : base(message) { }
    }
}


