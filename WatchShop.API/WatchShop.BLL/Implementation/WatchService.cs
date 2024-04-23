using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class WatchService : IWatchService
    {
        private IWatchRepository _watchRepository;

        public WatchService(IWatchRepository watchRepository)
        {
            _watchRepository = watchRepository;
        }

        public IEnumerable<WatchContract> GetAllWatches()
        {
            return _watchRepository.GetAllWatches();
        }

        public WatchContract GetWatchById(Guid id)
        {
            return _watchRepository.GetWatchById(id);
        }

        public async Task<AddWatchContract> AddWatch(AddWatchContract newWatch)
        {
            return await _watchRepository.AddWatch(newWatch);
        }

        public IEnumerable<WatchContract> GetWatchesByFilter(FilterContract filter)
        {
            return _watchRepository.GetWatchesByFilter(filter);
        }

        public bool DeleteWatch(Guid watchId)
        {
            return _watchRepository.DeleteWatch(watchId);
        }

        public bool UpdateWatch(AddWatchContract watch)
        {
            return _watchRepository.UpdateWatch(watch);
        }
    }
}
