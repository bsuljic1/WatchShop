using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts.Models;

namespace WatchShop.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public UserContract Get(Guid id)
        {
            return _userService.GetUserById(id);
        }

        [HttpGet]
        public UserContract GetByEmailAndPassword([FromQuery] string email, string password)
        {
            return _userService.GetByEmailAndPassword(email, password);
        }


        [HttpPost]
        public bool AddUser([FromBody] UserContract newUser)
        {
            return _userService.AddUser(newUser);
        }


        
        [HttpGet]
        [Route("role")]
        public RoleContract GetRole([FromQuery] Guid userId)
        {
            return _userService.GetRoleByUserId(userId);
        }

        [HttpGet]
        [Route("privilege")]
        public IEnumerable<PrivilegeContract> GetPrivilege([FromQuery] Guid roleId)
        {
            return _userService.GetPrivilegeByRoleId(roleId);
        }


    }
}
