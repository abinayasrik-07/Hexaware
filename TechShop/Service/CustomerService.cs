namespace TechShop.Service
{
    public interface CustomerService
    {
        void CalculateTotalOrders(int customerId);
        void GetCustomerDetails(int customerId);
        void UpdateCustomerInfo(int customerId, string email, string phone, string address);
    }
}
