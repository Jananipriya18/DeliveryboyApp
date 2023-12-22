using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deliveryboy.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Delivery>? DeliveryStatus { get; set; }
    }
}