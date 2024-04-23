using System;
using System.Collections.Generic;
using WatchShop.Contracts.Models;

namespace WatchShop.DAL.Interfaces
{
    public interface IUserRepository
    {
        public UserContract GetUserById(Guid id);
        public bool AddUser(UserContract newUser);
        public UserContract GetByEmailAndPassword(string email, string password);
        public RoleContract GetRoleByUserId(Guid id);
        public IEnumerable<PrivilegeContract> GetPrivilegeByRoleId(Guid roleId);
    }
}
