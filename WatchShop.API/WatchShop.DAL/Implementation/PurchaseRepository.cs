using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class PurchaseRepository : IPurchaseRepository
    {

        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public PurchaseRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool AddToPurchases(PurchaseContract newPurchase)
        {
            Purchase mappedPurchase = _mapper.Map<Purchase>(newPurchase);
            var watch = _dbContext.Watches.FirstOrDefault(w => w.WatchId == newPurchase.WatchId);
            watch.Available = watch.Available - newPurchase.Quantity;
            _dbContext.Watches.Update(watch);
            _dbContext.SaveChanges();


            Purchase newItemToPurchase = new Purchase
            {
                PurchaseId = Guid.NewGuid(),
                Quantity = newPurchase.Quantity,
                UserId = mappedPurchase.UserId,
                WatchId = mappedPurchase.WatchId,
                PurchasePrice = newPurchase.PurchasePrice,
                TimeOfPurchase = DateTime.Now
            };

            _dbContext.Purchases.Add(newItemToPurchase);
            _dbContext.SaveChanges();
            return true;
        }


        public IEnumerable<PurchaseContract> GetPurchasesByUserId(Guid userId)
        {
            var repoResult = _dbContext.Purchases.OrderBy(r => r.TimeOfPurchase).Where(purchase => purchase.UserId == userId).AsQueryable();
           
            return repoResult.Select(purchase => _mapper.Map<PurchaseContract>(purchase));
        }

    }
}
