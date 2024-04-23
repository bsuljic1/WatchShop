using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Brand
    {
        public Brand()
        {
            Watches = new HashSet<Watch>();
        }

        public Guid BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Watch> Watches { get; set; }
    }
}
