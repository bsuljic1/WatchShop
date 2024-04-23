using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class UserContract
    {
            public Guid UserId { get; set; }
            public string UserFirstName { get; set; }
            public string UserLastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
        }
}
