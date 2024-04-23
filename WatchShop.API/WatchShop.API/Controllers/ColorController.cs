using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("color")]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
    

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        public IEnumerable<ColorContract> GetAll()
        {
            return _colorService.GetAllColors();
        }

        [HttpGet("{id}")]
        public ColorContract Get(Guid id)
        {
            return _colorService.GetColorById(id);
        }


        [HttpGet]
        [Route("name")]
        public ColorContract GetColorByName([FromQuery]  string name)
        {
            return _colorService.GetColorByName(name);
        }



    }
}
