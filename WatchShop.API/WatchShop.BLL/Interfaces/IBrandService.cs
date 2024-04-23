using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.BLL.Interfaces
{
    public interface IBrandService
    {
        public IEnumerable<BrandContract> GetAllBrands();
        public BrandContract GetBrandById(Guid id);
        public BrandContract GetBrandByName(string name);
    }
}
