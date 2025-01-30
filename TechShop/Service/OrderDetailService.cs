namespace TechShop.Service
{
    public interface OrderDetailService
    {
        void CalculateSubtotal(int orderDetailId);
        void GetOrderDetailInfo(int orderDetailId);
        void UpdateQuantity(int orderDetailId, int newQuantity);
        void AddDiscount(int orderDetailId, decimal discountPercentage);
    }
}
