using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.Models
{
    public partial class Topping
    {
        public Topping()
        {
            OrderItemsDetails = new HashSet<OrderItemsDetail>();
        }

        public int ToppingsNumber { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<OrderItemsDetail> OrderItemsDetails { get; set; }
    }
}
