using System;
using System.Collections.Generic;

#nullable disable

namespace tienda_pamys_api.models
{
    public partial class OrderDetail
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int? Quantity { get; set; }

        public virtual Order IdOrderNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
