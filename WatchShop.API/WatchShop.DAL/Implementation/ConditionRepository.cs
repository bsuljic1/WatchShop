using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class ConditionRepository : IConditionRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public ConditionRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ConditionContract> GetAllConditions()
        {
            var repoResult = _dbContext.Conditions.AsQueryable();
            return repoResult.Select(conditions => _mapper.Map<ConditionContract>(conditions));
        }

        public ConditionContract GetConditionById(Guid id)
        {
            var repoResult = _dbContext.Conditions.Where(condition => condition.ConditionId == id);
            return repoResult.Select(condition => _mapper.Map<ConditionContract>(condition)).Single();
        }

        public ConditionContract GetConditionByName(string name)
        {
            var repoResult = _dbContext.Conditions.Where(condition => condition.ConditionName == name);
            return repoResult.Select(condition => _mapper.Map<ConditionContract>(condition)).Single();
        }
    }
}
