using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Cart
    {
        public Guid CartId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public Guid WatchId { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
