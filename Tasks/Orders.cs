using System;

namespace Tasks
{
    public struct Orders
    {
        private int orderNumber;
        private string status;

        public Orders(int orderNumber, string status)
        {
            this.orderNumber = orderNumber;
            this.status = status;
        }

        public int GetOrderNumber()
        {
            return orderNumber;
        }

        public void SetOrderNumber(int orderNumber)
        {
            this.orderNumber = orderNumber;
        }

        public string GetStatus()
        {
            return status;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }
    }


}
