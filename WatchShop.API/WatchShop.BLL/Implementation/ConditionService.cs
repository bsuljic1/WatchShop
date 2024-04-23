using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class ConditionService : IConditionService
    {
        private IConditionRepository _conditionRepository;

        public ConditionService(IConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public IEnumerable<ConditionContract> GetAllConditions()
        {
            return _conditionRepository.GetAllConditions();
        }

        public ConditionContract GetConditionById(Guid id)
        {
            return _conditionRepository.GetConditionById(id);
        }

        public ConditionContract GetConditionByName(string name)
        {
            return _conditionRepository.GetConditionByName(name);
        }
    }
}
