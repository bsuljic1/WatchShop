using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Color
    {
        public Color()
        {
            Watches = new HashSet<Watch>();
        }

        public Guid ColorId { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<Watch> Watches { get; set; }
    }
}
