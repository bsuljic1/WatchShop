using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Purchase
    {
        public Guid PurchaseId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public Guid UserId { get; set; }
        public Guid WatchId { get; set; }

        public virtual User User { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
