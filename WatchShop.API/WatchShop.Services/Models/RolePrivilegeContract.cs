using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class RolePrivilegeContract
    {
        public Guid RolePrivilegeId { get; set; }
        public Guid RoleId { get; set; }
        public Guid PrivilegeId { get; set; }

        public virtual PrivilegeContract Privilege { get; set; }
        public virtual RoleContract Role { get; set; }
    }
}
