using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class PurchaseContract
    {
        public Guid PurchaseId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public Guid UserId { get; set; }
        public Guid WatchId { get; set; }
    }
}
