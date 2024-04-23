using System;

namespace WatchShop.Contracts
{
    public class AddWatchContract
    {
        public Guid watchId { get; set; }
        public string Model { get; set; }
        public DateTime DatePublished { get; set; }
        public string BraceletMaterial { get; set; }
        public decimal CaseDiameter { get; set; }
        public int WaterResistant { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingPrice { get; set; }
        public int Guarantee { get; set; }
        public string ImagePath { get; set; }
        public int Available { get; set; }

        public Guid BrandId { get; set; }
        public Guid ColorId{ get; set; }
        public Guid ConditionId { get; set; }
        public Guid GenderId { get; set; }
    }
}
