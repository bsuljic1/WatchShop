using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("watch")]
    public class WatchController : ControllerBase
    {
        private readonly IWatchService _watchService;

        public WatchController(IWatchService watchService)
        {
            _watchService = watchService;
        }

        [HttpGet]
        public IEnumerable<WatchContract> GetAll()
        {
            return _watchService.GetAllWatches();
        }

        [HttpGet]
        [Route("filter")]
        public IEnumerable<WatchContract> GetWatchesByFilter([FromQuery] FilterContract filter)
        {
            return _watchService.GetWatchesByFilter(filter);
        }

        [HttpGet("{id}")]
        public WatchContract Get(Guid id)
        {
            return _watchService.GetWatchById(id);
        }

        [HttpPost]
        public async Task<bool> AddWatch([FromBody] AddWatchContract newWatch)
        {
            await _watchService.AddWatch(newWatch);
            return true;
        }

        [HttpDelete("{watchId}")]
        public bool DeleteWatchFromCart(Guid watchId)
        {
            return _watchService.DeleteWatch(watchId);
        }


        [HttpPut("{watchId}")]
        public bool UpdateWatch([FromBody] AddWatchContract watch)
        {
            return _watchService.UpdateWatch(watch);
        }

    }
}
