using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.BLL.Interfaces
{
    public interface IColorService
    {
        public IEnumerable<ColorContract> GetAllColors();
        public ColorContract GetColorById(Guid id);
        public ColorContract GetColorByName(string name);
    }
}
