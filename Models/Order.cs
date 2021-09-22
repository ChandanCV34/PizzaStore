using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int OrderId { get; set; }
        public string UserEmail { get; set; }
        public int? TotalAmount { get; set; }
        public int? DeliveryCharges { get; set; }
        public string Status { get; set; }

        public virtual User UserEmailNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
