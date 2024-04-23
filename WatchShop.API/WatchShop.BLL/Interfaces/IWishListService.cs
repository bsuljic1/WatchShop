using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;

namespace WatchShop.BLL.Interfaces
{
    public interface IWishListService
    {
        public IEnumerable<WishListContract> GetWishListByUserId(Guid id);
        public bool RemoveFromWishList(Guid id);
        public void AddToWishList(Guid watchId, Guid userId);
    }
}
