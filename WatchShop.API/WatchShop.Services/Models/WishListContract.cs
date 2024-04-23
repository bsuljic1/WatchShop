using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class WishListContract
    {
        public Guid WishListId { get; set; }
        public Guid WatchId { get; set; }
        public Guid UserId { get; set; }

    }
}
