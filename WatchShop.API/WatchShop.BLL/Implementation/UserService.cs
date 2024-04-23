using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(UserContract newUser)
        {
            return _userRepository.AddUser(newUser);
        }

        public UserContract GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }

        public UserContract GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetByEmailAndPassword(email, password); 
        }

        public RoleContract GetRoleByUserId(Guid id)
        {
            return _userRepository.GetRoleByUserId(id);
        }

        public IEnumerable<PrivilegeContract> GetPrivilegeByRoleId(Guid roleId)
        {
            return _userRepository.GetPrivilegeByRoleId(roleId);
        }
    }
}

