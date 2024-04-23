using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts.Models;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IEnumerable<CartContract> GetByUserId(Guid userId)
        {
            return _cartService.GetCartByUserId(userId);
        }

        [HttpDelete("{cartId}")]
        public void DeleteWatchFromCart(Guid cartId)
        {
            _cartService.DeleteWatchFromCart(cartId);
        }


        [HttpPost]
        public bool AddToCart([FromBody] CartContract newCartItem)
        {
            _cartService.AddToCart(newCartItem);
            return true;
        }

        [HttpPut("{cartId}")]
        public bool UpdateCartItem([FromBody] UpdateCartContract cart)
        {
            return _cartService.UpdateCartItem(cart.CartId, cart.Quantity);
        }
    }
}

