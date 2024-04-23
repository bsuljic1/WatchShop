using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;
using WatchShop.Model;

namespace WatchShop.DAL.Implementation
{
    public class ColorRepository : IColorRepository
    {
        private readonly IMapper _mapper;
        private readonly WatchShopDatabaseContext _dbContext;

        public ColorRepository(WatchShopDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ColorContract> GetAllColors()
        {
            var repoResult = _dbContext.Colors.AsQueryable();
            return repoResult.Select(colors => _mapper.Map<ColorContract>(colors));
        }

        public ColorContract GetColorById(Guid id)
        {
            var repoResult = _dbContext.Colors.Where(color => color.ColorId == id);
            return repoResult.Select(color => _mapper.Map<ColorContract>(color)).Single();
        }

        public ColorContract GetColorByName(string name)
        {
            var repoResult = _dbContext.Colors.Where(color => color.ColorName == name);
            return repoResult.Select(color => _mapper.Map<ColorContract>(color)).Single();
        }
    }
}
