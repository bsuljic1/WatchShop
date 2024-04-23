using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class RolePrivilege
    {
        public Guid RolePrivilegeId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PrivilegeId { get; set; }

        public virtual Privilege Privilege { get; set; }
        public virtual Role Role { get; set; }
    }
}
