using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;

namespace WatchShop.DAL.Interfaces
{
    public interface ICartRepository
    {
        public IEnumerable<CartContract> GetCartByUserId(Guid userId);
        public void DeleteWatchFromCart(Guid cartId);
        public bool AddToCart(CartContract newCartItem);
        public bool UpdateCartItem(Guid cartId, int quantity);
    }
}
