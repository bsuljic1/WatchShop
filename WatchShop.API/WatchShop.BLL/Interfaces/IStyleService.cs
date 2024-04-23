using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.BLL.Interfaces
{
    public interface IStyleService
    {
        public IEnumerable<StyleContract> GetAllStyles();
    }
}
