using System;

namespace TechShop.Model
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Products(int productId, string productName, string description, decimal price)
        {
            ProductID = productId;
            ProductName = productName;
            Description = description;
            Price = price;
        }
        public override string ToString()
        {
            return $"ProductId::{ProductID}\tProductName::{ProductName}\tDescription::{Description}\tPrice::{Price}";
        }
    }
}
