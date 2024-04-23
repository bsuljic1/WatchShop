using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.DAL.Interfaces
{
    public interface IColorRepository
    {
        public IEnumerable<ColorContract> GetAllColors();
        public ColorContract GetColorById(Guid id);
        public ColorContract GetColorByName(string name);
    }
}
