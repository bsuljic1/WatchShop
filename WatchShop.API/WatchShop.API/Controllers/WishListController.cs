using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts.Models;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("wishList")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpGet("{id}")]
        public IEnumerable<WishListContract> GetWishListByUserId(Guid id) => _wishListService.GetWishListByUserId(id);


        [HttpPost]
        public bool AddToWishList([FromBody] WishListContract wl)
        {
            _wishListService.AddToWishList(wl.WatchId, wl.UserId);
            return true;
        }

        [HttpDelete("{id}")]
        public bool RemoveFromWishList(Guid id)
        {
            return _wishListService.RemoveFromWishList(id);
        }


    }
}
