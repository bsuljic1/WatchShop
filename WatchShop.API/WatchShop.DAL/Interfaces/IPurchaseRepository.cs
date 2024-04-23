using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;

namespace WatchShop.DAL.Interfaces
{
    public interface IPurchaseRepository
    {
        public IEnumerable<PurchaseContract> GetPurchasesByUserId(Guid userId);
        public bool AddToPurchases(PurchaseContract newPurchase);
    }
}
