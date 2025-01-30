using System;

namespace TechShop.Model
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Customers Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Orders(int orderId, Customers customer, DateTime orderDate, decimal totalAmount)
        {
            OrderID = orderId;
            Customer = customer;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }
        public override string ToString()
        {
            return $"OrderId::{OrderID}\tCustomer::{Customer}\tOrderDate::{OrderDate}\tTotalAmount::{TotalAmount}";
        }
    }
}
