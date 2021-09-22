using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int PizzaNumber { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Type { get; set; }

        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
