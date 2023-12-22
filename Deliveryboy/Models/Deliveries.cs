using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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