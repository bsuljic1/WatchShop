
using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.DAL.Interfaces
{
    public interface IBrandRepository
    {
        public IEnumerable<BrandContract> GetAllBrands();
        public BrandContract GetBrandById(Guid id);
        public BrandContract GetBrandByName(string name);
    }
}
