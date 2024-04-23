using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Style
    {
        public Style()
        {
            StyleWatches = new HashSet<StyleWatch>();
        }

        public Guid StyleId { get; set; }
        public string StyleName { get; set; }

        public virtual ICollection<StyleWatch> StyleWatches { get; set; }
    }
}
