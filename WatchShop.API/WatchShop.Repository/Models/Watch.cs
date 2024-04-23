using System;
using System.Collections.Generic;

#nullable disable

namespace WatchShop.Model
{
    public partial class Watch
    {
        public Watch()
        {
            Carts = new HashSet<Cart>();
            Purchases = new HashSet<Purchase>();
            StyleWatches = new HashSet<StyleWatch>();
            WishLists = new HashSet<WishList>();
        }


        public Guid WatchId { get; set; }
        public string Model { get; set; }
        public DateTime DatePublished { get; set; }
        public string BraceletMaterial { get; set; }
        public decimal CaseDiameter { get; set; }
        public int WaterResistant { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingPrice { get; set; }
        public int Guarantee { get; set; }
        public string ImagePath { get; set; }
        public Guid BrandId { get; set; }
        public Guid GenderId { get; set; }
        public Guid ConditionId { get; set; }
        public Guid ColorId { get; set; }
        public int Available { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Color Color { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<StyleWatch> StyleWatches { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }
}
