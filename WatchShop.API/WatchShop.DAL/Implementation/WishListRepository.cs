using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class WishListRepository : IWishListRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public WishListRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void AddToWishList(Guid watchId, Guid userId)
        {
            WishList wl = new WishList
            {
                WishListId = Guid.NewGuid(),
                WatchId = watchId,
                UserId = userId
            };
            _dbContext.WishLists.Add(wl);
            _dbContext.SaveChanges();
        }


        public IEnumerable<WishListContract> GetWishListByUserId(Guid id)
        {
            var repoResult = _dbContext.WishLists.Where(w => w.UserId == id).AsQueryable();
            return repoResult.Select(wl => _mapper.Map<WishListContract>(wl));
        }

        public bool RemoveFromWishList(Guid id)
        {
            var wl = _dbContext.WishLists.Where(w => w.WishListId == id).Single();
            _dbContext.Remove(wl);

            _dbContext.SaveChanges();
            return true;
        }
    }
}
