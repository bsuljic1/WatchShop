using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.DAL.Interfaces
{
    public interface IStyleRepository
    {
        public IEnumerable<StyleContract> GetAllStyles();
    }
}
