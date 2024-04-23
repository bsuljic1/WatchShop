using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("condition")]
    public class ConditionController : ControllerBase
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpGet]
        public IEnumerable<ConditionContract> GetAll()
        {
            return _conditionService.GetAllConditions();
        }

        [HttpGet("{id}")]
        public ConditionContract Get(Guid id)
        {
            return _conditionService.GetConditionById(id);
        }

        [HttpGet]
        [Route("name")]
        public ConditionContract GetConditionByName([FromQuery]  string name)
        {
            return _conditionService.GetConditionByName(name);
        }

    }
}
