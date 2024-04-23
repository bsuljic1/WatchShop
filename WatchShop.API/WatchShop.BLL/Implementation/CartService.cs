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
    public class CartService : ICartService { 
        private ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public bool AddToCart(CartContract newCartItem)
        {
            return _cartRepository.AddToCart(newCartItem);
        }

        public void DeleteWatchFromCart(Guid cartId)
        {
            _cartRepository.DeleteWatchFromCart(cartId);
        }

        public IEnumerable<CartContract> GetCartByUserId(Guid userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }

        public bool UpdateCartItem(Guid cartId, int quantity)
        {
            return _cartRepository.UpdateCartItem(cartId, quantity);
        }
    }
}
