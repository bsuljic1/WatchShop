using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model { 
    public partial class StyleWatch
    {
        public Guid StyleWatchId { get; set; }
        public Guid StyleId { get; set; }
        public Guid WatchId { get; set; }

        public virtual Style Style { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
