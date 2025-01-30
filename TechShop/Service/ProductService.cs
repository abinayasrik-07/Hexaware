namespace TechShop.Service
{
    public interface ProductService
    {
        void GetProductDetails(int productId);
        void UpdateProductInfo(int productId, string description, decimal price);
        bool IsProductInStock(int productId);
    }
}
