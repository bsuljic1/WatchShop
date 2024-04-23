using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Gender
    {
        public Gender()
        {
            Watches = new HashSet<Watch>();
        }

        public Guid GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Watch> Watches { get; set; }
    }
}
