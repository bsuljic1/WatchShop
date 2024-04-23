using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class WatchRepository : IWatchRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public WatchRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AddWatchContract> AddWatch(AddWatchContract newWatch)
        {
            var mappedObj = _mapper.Map<Watch>(newWatch);
            mappedObj.WatchId = Guid.NewGuid();
            mappedObj.ColorId = newWatch.ColorId;
            mappedObj.BrandId = newWatch.BrandId;
            mappedObj.ConditionId = newWatch.ConditionId;
            mappedObj.GenderId = newWatch.GenderId;

            _dbContext.Watches.AddAsync(mappedObj);
            _dbContext.SaveChanges();
            return _mapper.Map<AddWatchContract>(mappedObj);
        }
        

        public bool DeleteWatch(Guid watchId)
        {
            var watch = _dbContext.Watches.Where(w => w.WatchId == watchId).Single();
            _dbContext.Remove(watch);

            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<WatchContract> GetAllWatches()
        {
            var repoResult = _dbContext.Watches
                .Include(x => x.Brand)
                .Include(x => x.Color)
                .Include(x => x.Condition)
                .Include(x => x.Gender).ToList();
            return repoResult.Select(watches => _mapper.Map<WatchContract>(watches));
        }

        public WatchContract GetWatchById(Guid id)
        {
            var repoResult = _dbContext.Watches
                .Include(x => x.Brand)
                .Include(x => x.Color)
                .Include(x => x.Condition)
                .Include(x => x.Gender).Where(watch => watch.WatchId == id);
            return repoResult.Select(watch => _mapper.Map<WatchContract>(watch)).Single();
        }

        public IEnumerable<WatchContract> GetWatchesByFilter(FilterContract filter)
        {
            IQueryable<Watch> result = _dbContext.Watches
                .Include(x => x.Brand)
             .Include(x => x.Color)
             .Include(x => x.Condition)
             .Include(x => x.Gender);

            if (filter.SearchText != "")
                result = result.Where(w => ((w.Brand.BrandName + ' ' + w.Model).Contains(filter.SearchText.ToLower())));


            if (filter.GenderName != "")
                result = result.Where(w => w.Gender.GenderName == filter.GenderName);

            if (filter.BrandName != "")
                result = result.Where(w => w.Brand.BrandName == filter.BrandName);

            if (filter.ConditionName != "")
                result = result.Where(w => w.Condition.ConditionName == filter.ConditionName);

            //if (filter.StyleName != "")
            //    foreach (string styleName in filter.StyleNames)
            //        result = result.Where(w => w.StyleWatches == conditionName);

            if (filter.ColorName != "")
                result = result.Where(w => w.Color.ColorName == filter.ColorName);

            if(filter.SortBy != "")
            {
                if(filter.SortBy == "nameAsc")
                {
                    result = result.OrderBy(w => w.Brand.BrandName).OrderBy(w => w.Model);
                }
                else if(filter.SortBy == "nameDesc")
                {
                    result = result.OrderByDescending(w => w.Brand.BrandName).OrderByDescending(w => w.Model);
                }
                else if(filter.SortBy == "priceAsc")
                {
                    result = result.OrderBy(w => w.Price);
                }
                else if(filter.SortBy == "priceDesc")
                {
                    result = result.OrderByDescending(w => w.Price);
                }
            }

            result = result.Where(w => w.Price >= filter.MinPrice && w.Price <= filter.MaxPrice);

            return result.Select(watches => _mapper.Map<WatchContract>(watches));
        }

        public bool UpdateWatch(AddWatchContract watch)
        {
            var w = _dbContext.Watches.Where(w => w.WatchId == watch.watchId).Single();
            w.Available = watch.Available;
            w.DatePublished = watch.DatePublished;
            w.CaseDiameter = watch.CaseDiameter;
            w.WaterResistant = watch.WaterResistant;
            w.ColorId = watch.ColorId;
            w.BrandId = watch.BrandId;
            w.ConditionId = watch.ConditionId;
            w.GenderId = watch.GenderId;
            w.BraceletMaterial = watch.BraceletMaterial;
            w.Price = watch.Price;
            w.ShippingPrice = watch.ShippingPrice;
            w.Guarantee = watch.Guarantee;
            w.ImagePath = watch.ImagePath;
            w.Model = watch.Model;
            _dbContext.Watches.Update(w);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
