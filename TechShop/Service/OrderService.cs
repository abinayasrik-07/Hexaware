namespace TechShop.Service
{
    public interface OrderService
    {
        void CalculateTotalAmount(int orderId);
        void GetOrderDetails(int orderId);
        void UpdateOrderStatus(int orderId, string status);
        void CancelOrder(int orderId);
    }
}
