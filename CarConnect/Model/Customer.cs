using System;

namespace CarConnect.Model
{
    public class Customer
    {
        private int _customerID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _address;
        private string _username;
        private string _password;
        private DateTime _registrationDate;

        public Customer() { }

        public Customer(int customerID, string firstName, string lastName, string email,
                        string phoneNumber, string address, string username,
                        string password, DateTime registrationDate)
        {
            _customerID = customerID;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _address = address;
            _username = username;
            _password = password;
            _registrationDate = registrationDate;
        }

        public int CustomerID { get => _customerID; set => _customerID = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Address { get => _address; set => _address = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime RegistrationDate { get => _registrationDate; set => _registrationDate = value; }

        public bool Authenticate(string password)
        {
            return _password == password;
        }
    }
}

