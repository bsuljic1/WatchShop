using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class PurchaseService : IPurchaseService
    {
        private IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public bool AddToPurchases(PurchaseContract newPurchase)
        {
            return _purchaseRepository.AddToPurchases(newPurchase);
        }

        public IEnumerable<PurchaseContract> GetPurchasesByUserId(Guid userId)
        {
            return _purchaseRepository.GetPurchasesByUserId(userId);
        }
    }
}
