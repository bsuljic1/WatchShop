using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;

namespace WatchShop.BLL.Interfaces
{
    public interface IPurchaseService
    {
        public IEnumerable<PurchaseContract> GetPurchasesByUserId(Guid userId);
        public bool AddToPurchases(PurchaseContract newPurchase);
    }
}
