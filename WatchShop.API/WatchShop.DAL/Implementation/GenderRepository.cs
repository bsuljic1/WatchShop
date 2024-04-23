using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class GenderRepository : IGenderRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public GenderRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<GenderContract> GetAllGenders()
        {
            var repoResult = _dbContext.Genders.AsQueryable();
            return repoResult.Select(genders => _mapper.Map<GenderContract>(genders));
        }

        public GenderContract GetGenderById(Guid id)
        {

            var repoResult = _dbContext.Genders.Where(gender => gender.GenderId == id);
            return repoResult.Select(gender => _mapper.Map<GenderContract>(gender)).Single();
        }

        public GenderContract GetGenderByName(string name)
        {
            var repoResult = _dbContext.Genders.Where(gender => gender.GenderName == name);
            return repoResult.Select(gender => _mapper.Map<GenderContract>(gender)).Single();
        }
    }
}
