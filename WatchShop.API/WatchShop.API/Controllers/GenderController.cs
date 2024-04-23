using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("gender")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;


        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public IEnumerable<GenderContract> GetAll()
        {
            return _genderService.GetAllGenders();
        }

        [HttpGet("{id}")]
        public GenderContract Get(Guid id)
        {
            return _genderService.GetGenderById(id);
        }

        [HttpGet]
        [Route("name")]
        public GenderContract GetGenderByName([FromQuery] string name)
        {
            return _genderService.GetGenderByName(name);
        }

    }
}
