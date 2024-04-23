using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;

namespace WatchShop.DAL.Interfaces
{
    public interface IWatchRepository
    {
        public IEnumerable<WatchContract> GetAllWatches();
        public IEnumerable<WatchContract> GetWatchesByFilter(FilterContract filter);
        public WatchContract GetWatchById(Guid id);
        public Task<AddWatchContract> AddWatch(AddWatchContract newWatch);
        public bool DeleteWatch(Guid watchId);
        public bool UpdateWatch(AddWatchContract watch);
    }
}
