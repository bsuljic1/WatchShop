using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Role
    {
        public Role()
        {
            RolePrivileges = new HashSet<RolePrivilege>();
            UserRoles = new HashSet<UserRole>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivileges { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
