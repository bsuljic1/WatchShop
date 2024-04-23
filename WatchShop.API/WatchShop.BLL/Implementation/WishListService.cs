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
    public class WishListService : IWishListService
    {
        private IWishListRepository _wishListRepository;

        public WishListService(IWishListRepository wishListRepository)
        {
            _wishListRepository = wishListRepository;
        }

        public void AddToWishList(Guid watchId, Guid userId)
        {
            _wishListRepository.AddToWishList(watchId, userId);
        }

        public IEnumerable<WishListContract> GetWishListByUserId(Guid id)
        {
            return _wishListRepository.GetWishListByUserId(id);
        }

        public bool RemoveFromWishList(Guid id)
        {
            return _wishListRepository.RemoveFromWishList(id);
        }
    }
}
