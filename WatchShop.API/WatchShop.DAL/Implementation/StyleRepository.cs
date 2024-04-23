using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class StyleRepository : IStyleRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public StyleRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<StyleContract> GetAllStyles()
        {
            var repoResult = _dbContext.Styles.AsQueryable();
            return repoResult.Select(styles => _mapper.Map<StyleContract>(styles));
        }
    }
}
