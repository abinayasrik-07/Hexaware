using System;
using System.Net;
using System.Numerics;

namespace TechShop.Model
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public Products Product { get; set; } 
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Inventory(int inventoryId, Products product, int quantityInStock, DateTime lastStockUpdate)
        {
            InventoryID = inventoryId;
            Product = product;
            QuantityInStock = quantityInStock;
            LastStockUpdate = lastStockUpdate;
        }
        public override string ToString()
        {
            return $"InventoryId::{InventoryID}\tProduct::{Product}\tQuantityInStock::{QuantityInStock}\tLastStockUpdate::{LastStockUpdate}";
        }
    }
}
