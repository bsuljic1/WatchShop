using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.BLL.Interfaces
{
    public interface IConditionService
    {
        public IEnumerable<ConditionContract> GetAllConditions();
        public ConditionContract GetConditionById(Guid id);
        public ConditionContract GetConditionByName(string name);
    }
}
