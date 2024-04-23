using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.DAL.Interfaces
{
    public interface IConditionRepository
    {
        public IEnumerable<ConditionContract> GetAllConditions();
        public ConditionContract GetConditionById(Guid id);
        public ConditionContract GetConditionByName(string name);
    }
}
