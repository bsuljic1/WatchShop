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
    [Route("purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public IEnumerable<PurchaseContract> GetPurchasesByUserId(Guid userId)
        {
            return _purchaseService.GetPurchasesByUserId(userId);
        }


        [HttpPost]
        public bool AddToPurchases([FromBody] PurchaseContract newPurchase)
        {
            _purchaseService.AddToPurchases(newPurchase);
            return true;
        }

    }
}
