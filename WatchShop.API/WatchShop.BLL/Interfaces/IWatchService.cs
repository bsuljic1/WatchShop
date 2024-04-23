using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;

namespace WatchShop.BLL.Interfaces
{
    public interface IWatchService
    {
        public IEnumerable<WatchContract> GetAllWatches();
        public IEnumerable<WatchContract> GetWatchesByFilter(FilterContract filter);
        public WatchContract GetWatchById(Guid id);
        public Task<AddWatchContract> AddWatch(AddWatchContract newWatch);
        public bool DeleteWatch(Guid watchId);
        public bool UpdateWatch(AddWatchContract watch);
    }
}
