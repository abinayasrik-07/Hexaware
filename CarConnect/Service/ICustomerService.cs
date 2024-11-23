
using CarConnect.Model;

namespace CarConnect.Service
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int customerId);
        Customer GetCustomerByUsername(string username);
        void RegisterCustomer(Customer customerData);
        void UpdateCustomer(Customer customerData);
        void DeleteCustomer(int customerId);
    }
}

