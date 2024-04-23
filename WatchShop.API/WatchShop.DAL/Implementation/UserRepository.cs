using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchShop.Contracts.Models;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public UserRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserContract GetUserById(Guid id)
        {
            var repoResult = _dbContext.Users.Where(user => user.UserId == id);
            return repoResult.Select(user => _mapper.Map<UserContract>(user)).Single();
        }


        public bool AddUser(UserContract newUser)
        {
            var repoResult = _dbContext.Users.FirstOrDefault(user => user.Email == newUser.Email);

            if (repoResult != null)
            {
                return false;
            }
            else
            {
                User mappedUser = _mapper.Map<User>(newUser);
                mappedUser.UserId = Guid.NewGuid();
                _dbContext.Users.Add(mappedUser);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public UserContract GetByEmailAndPassword(string email, string password)
        {
            var repoResult = _dbContext.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            if(repoResult == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<UserContract>(repoResult);
            }
        }

        public RoleContract GetRoleByUserId(Guid id)
        {
            var repoResult = _dbContext.UserRoles.Where(userRole => userRole.UserId == id).Single();
            var res2 = _dbContext.Roles.Where(role => role.RoleId == repoResult.RoleId).Single();

            return _mapper.Map<RoleContract>(res2);
        }

        public IEnumerable<PrivilegeContract> GetPrivilegeByRoleId(Guid roleId)
        {
            var repoResult = _dbContext.RolePrivileges.Where(rolePrivilege => rolePrivilege.RoleId == roleId).ToList();
            var privileges = new List<Privilege>();
            foreach(var r in repoResult)
            {
                privileges.Add(_dbContext.Privileges.Where(privilege => privilege.PrivilegeId == r.PrivilegeId).Single());
            }


            return privileges.Select(p => _mapper.Map<PrivilegeContract>(p));
        }
    }
}

