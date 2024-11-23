
using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using System;

namespace CarConnect.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }

        public Customer GetCustomerByUsername(string username)
        {
            return _customerRepository.GetCustomerByUsername(username);
        }

        public void RegisterCustomer(Customer customerData)
        {
            if (string.IsNullOrEmpty(customerData.Username) || string.IsNullOrEmpty(customerData.Password))
            {
                throw new ArgumentException("Username and Password cannot be empty.");
            }
            _customerRepository.RegisterCustomer(customerData);
        }

        public void UpdateCustomer(Customer customerData)
        {
            _customerRepository.UpdateCustomer(customerData);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }
    }
}

