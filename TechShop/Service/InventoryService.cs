namespace TechShop.Service
{
    public interface InventoryService
    {
        void GetProduct(int inventoryId);
        int GetQuantityInStock(int inventoryId);
        void AddToInventory(int inventoryId, int quantity);
        void RemoveFromInventory(int inventoryId, int quantity);
        void UpdateStockQuantity(int inventoryId, int newQuantity);
        bool IsProductAvailable(int inventoryId, int quantityToCheck);
        decimal GetInventoryValue();
        void ListLowStockProducts(int threshold);
        void ListOutOfStockProducts();
        void ListAllProducts();
    }
}

