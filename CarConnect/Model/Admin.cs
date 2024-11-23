using System;

namespace CarConnect.Model
{
    public class Admin
    {
        private int _adminID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;
        private string _username;
        private string _password;
        private string _role;
        private DateTime _joinDate;

        public Admin() { }

        public Admin(int adminID, string firstName, string lastName, string email, string phoneNumber, string username, string password, string role, DateTime joinDate)
        {
            _adminID = adminID;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phoneNumber = phoneNumber;
            _username = username;
            _password = password;
            _role = role;
            _joinDate = joinDate;
        }

        public int AdminID { get => _adminID; set => _adminID = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Role { get => _role; set => _role = value; }
        public DateTime JoinDate { get => _joinDate; set => _joinDate = value; }

        public bool Authenticate(string password)
        {
            return _password == password;
        }
    }
}
