using System;

namespace WatchShop.Contracts
{
    public class WatchContract
    {
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
        public int Available { get; set; }

        public BrandContract  Brand { get; set; }
        public ColorContract Color { get; set; }
        public ConditionContract Condition { get; set; }
        public GenderContract Gender { get; set; }

    }
}
