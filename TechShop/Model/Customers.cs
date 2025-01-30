using System;
using System.Diagnostics;

namespace TechShop.Model
{
    internal class Customers
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public override string ToString()
        {
            return $"CustomerId::{CustomerID}\tName::{FirstName}\tName::{LastName}\tEmail::{Email}\tPhone::{Phone}\tAddress::{Address}";
        }
    }
}
