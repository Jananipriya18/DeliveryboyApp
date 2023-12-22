using System;

namespace Deliveryboy.Models
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        public DateTime Date { get; set; }
        public int OrderID { get; set; }
        public string Status { get; set; }
        public Order Order { get; set; }
    }
}
