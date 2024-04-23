using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Purchases = new HashSet<Purchase>();
            UserRoles = new HashSet<UserRole>();
            WishLists = new HashSet<WishList>();
        }

        public Guid UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
