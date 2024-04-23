using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class StyleService : IStyleService
    {
        private IStyleRepository _styleRepository;

        public StyleService(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public IEnumerable<StyleContract> GetAllStyles()
        {
            return _styleRepository.GetAllStyles();
        }
    }
}
