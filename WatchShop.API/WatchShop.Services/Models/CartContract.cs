using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class CartContract
    {
        public Guid CartId { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public Guid WatchId { get; set; }
        public Guid UserId { get; set; }
    }
}
