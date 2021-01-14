using System;
using System.Collections.Generic;

#nullable disable

namespace tienda_pamys_api.models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? IdClient { get; set; }
        public string ShippingAddress { get; set; }
        public int? Status { get; set; }
        public double? Total { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
