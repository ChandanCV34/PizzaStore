using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaStore.Models
{
    public partial class OrdersDetail
    {
        public OrdersDetail()
        {
            OrderItemsDetails = new HashSet<OrderItemsDetail>();
        }

        public int ItemNumber { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaNumber { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza PizzaNumberNavigation { get; set; }
        public virtual ICollection<OrderItemsDetail> OrderItemsDetails { get; set; }
    }
}
