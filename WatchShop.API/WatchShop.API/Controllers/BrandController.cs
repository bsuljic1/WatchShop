using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("brand")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IEnumerable<BrandContract> GetAll()
        {
            return _brandService.GetAllBrands();
        }

        [HttpGet("{id}")]
        public BrandContract Get(Guid id)
        {
            return _brandService.GetBrandById(id);
        }

        [HttpGet]
        [Route("name")]
        public BrandContract Get([FromQuery] string name)
        {
            return _brandService.GetBrandByName(name);
        }
    }
}
