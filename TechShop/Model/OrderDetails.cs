using System;

namespace TechShop.Model
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; } 
        public int Quantity { get; set; }

        public OrderDetails(int orderDetailId, Orders order, Products product, int quantity)
        {
            OrderDetailID = orderDetailId;
            Order = order;
            Product = product;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"OrderDetailId::{OrderDetailID}\tOrders::{Order}\tProducts::{Product}\tQuantity::{Quantity}";
        }
    }
}
