using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IEnumerable<BrandContract> GetAllBrands()
        {
            return _brandRepository.GetAllBrands();
        }

        public BrandContract GetBrandById(Guid id)
        {
            return _brandRepository.GetBrandById(id);
        }

        public BrandContract GetBrandByName(string name)
        {
            return _brandRepository.GetBrandByName(name);
        }
    }
}
