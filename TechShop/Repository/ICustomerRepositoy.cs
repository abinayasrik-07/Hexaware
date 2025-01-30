using TechShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Repository
{
    internal interface ICustomerRepository
    {
        List<Customers> GetAllCustomer();
        string ValidateEmail(string email);
        string SetCustomerDetails(string name, string email, string phone, string address);
        string GetCustomerDetails(int customerId);
    }
}