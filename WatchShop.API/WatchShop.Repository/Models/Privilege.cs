using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Privilege
    {
        public Privilege()
        {
            RolePrivileges = new HashSet<RolePrivilege>();
        }

        public Guid PrivilegeId { get; set; }
        public string PrivilegeName { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
