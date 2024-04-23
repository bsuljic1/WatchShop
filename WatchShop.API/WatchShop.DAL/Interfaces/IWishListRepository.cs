using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;

namespace WatchShop.DAL.Interfaces
{
    public interface IWishListRepository
    {
        public void AddToWishList(Guid watchId, Guid userId);
        public IEnumerable<WishListContract> GetWishListByUserId(Guid id);
        public bool RemoveFromWishList(Guid id);
    }
}
