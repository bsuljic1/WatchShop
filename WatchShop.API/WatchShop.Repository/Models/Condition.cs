using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Condition
    {
        public Condition()
        {
            Watches = new HashSet<Watch>();
        }

        public Guid ConditionId { get; set; }
        public string ConditionName { get; set; }

        public virtual ICollection<Watch> Watches { get; set; }
    }
}
