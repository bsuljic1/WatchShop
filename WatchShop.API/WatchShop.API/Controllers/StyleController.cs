using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("style")]
    public class StyleController : ControllerBase
    {
        private readonly IStyleService _styleService;


        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpGet]
        public IEnumerable<StyleContract> GetAll()
        {
            return _styleService.GetAllStyles();
        }

    }
}
