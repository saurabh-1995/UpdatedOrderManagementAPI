using System;
using System.Collections.Generic;

namespace OrderManagementWebAPI.Models
{
    public partial class OrderMaster
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
