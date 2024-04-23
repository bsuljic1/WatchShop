using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class UserRoleContract
    {
        
            public Guid UserId { get; set; }
            public Guid RoleId { get; set; }

            public virtual RoleContract Role { get; set; }
            public virtual UserContract User { get; set; }
       
    }
}
