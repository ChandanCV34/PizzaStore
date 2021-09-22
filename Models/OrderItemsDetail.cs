using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.Models
{
    public partial class OrderItemsDetail
    {
        public int ItemNumber { get; set; }
        public int ToppingsNumber { get; set; }

        public virtual OrdersDetail ItemNumberNavigation { get; set; }
        public virtual Topping ToppingsNumberNavigation { get; set; }
    }
}
