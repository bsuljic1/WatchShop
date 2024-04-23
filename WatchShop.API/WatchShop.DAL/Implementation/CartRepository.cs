using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public CartRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool AddToCart(CartContract newCartItem)
        {
            var repoResult = _dbContext.Carts.FirstOrDefault(c => c.WatchId == newCartItem.WatchId);

            var watch = _dbContext.Watches.FirstOrDefault(w => w.WatchId == newCartItem.WatchId);
            watch.Available = watch.Available - newCartItem.Quantity;
            _dbContext.Watches.Update(watch);
            _dbContext.SaveChanges();

            if (repoResult != null)
            {
                repoResult.Quantity = repoResult.Quantity + 1;
                _dbContext.Carts.Update(repoResult);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                Cart mappedCart = _mapper.Map<Cart>(newCartItem);

                Cart newItemToCart = new Cart
                {
                    CartId = Guid.NewGuid(),
                    Quantity = newCartItem.Quantity,
                    UserId = mappedCart.UserId,
                    WatchId = mappedCart.WatchId,
                    TotalPrice = newCartItem.TotalPrice
                };

                _dbContext.Carts.Add(newItemToCart);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public bool UpdateCartItem(Guid cartId, int quantity)
        {
            var cart = _dbContext.Carts.Where(c => c.CartId == cartId).Single();
            cart.Quantity = quantity;
            _dbContext.Carts.Update(cart);
            _dbContext.SaveChanges();
            return true;
        }

        public void DeleteWatchFromCart(Guid cartId)
        {
            var cart = _dbContext.Carts.Where(c => c.CartId == cartId).Single();
            _dbContext.Remove(cart);

            _dbContext.SaveChanges();
        }

        public IEnumerable<CartContract> GetCartByUserId(Guid userId)
        {
            var repoResult = _dbContext.Carts.Where(cart => cart.UserId == userId).AsQueryable();
            return repoResult.Select(cart => _mapper.Map<CartContract>(cart));
        }
    }
}
