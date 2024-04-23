using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchShop.Contracts.Models
{
    public class FilterContract
    {
        public string GenderName { get; set; } = "";
        public string BrandName { get; set; } = "";
        public string ConditionName { get; set; } = "";
        public string StyleName { get; set; } = "";
        public string ColorName { get; set; } = "";
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 100000;
        public string SearchText { get; set; } = "";
        public string SortBy { get; set; } = "";
    }
}
