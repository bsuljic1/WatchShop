using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public BrandRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<BrandContract> GetAllBrands()
        {
            var repoResult = _dbContext.Brands.AsQueryable();
            return repoResult.Select(brands => _mapper.Map<BrandContract>(brands));
        }

        public BrandContract GetBrandById(Guid id)
        {
            var repoResult = _dbContext.Brands.Where(brand => brand.BrandId == id);
            return repoResult.Select(brand => _mapper.Map<BrandContract>(brand)).Single();
        }

        public BrandContract GetBrandByName(string name)
        {
            var repoResult = _dbContext.Brands.Where(brand => brand.BrandName == name);
            return repoResult.Select(brand => _mapper.Map<BrandContract>(brand)).Single();
        }
    }

}
