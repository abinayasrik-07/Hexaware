using System;
using TechShop.Model;
using TechShop.Service;
using TechShop.Repository;
using TechShop;

class Program
{
    static void Main()
    {
        var customer = new Customers(1, "John", "Doe", "john.doe@example.com", "1234567890", "123 Main St");
    }
}


