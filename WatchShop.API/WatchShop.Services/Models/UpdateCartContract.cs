using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class UpdateCartContract
    {
        public Guid CartId { get; set; }
        public int Quantity { get; set; } 
    }
}
