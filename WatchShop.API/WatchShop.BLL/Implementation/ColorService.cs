using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class ColorService : IColorService
    {
        private IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public IEnumerable<ColorContract> GetAllColors()
        {
            return _colorRepository.GetAllColors();
        }

        public ColorContract GetColorById(Guid id)
        {
            return _colorRepository.GetColorById(id);
        }

        public ColorContract GetColorByName(string name)
        {
            return _colorRepository.GetColorByName(name);
        }
    }
}
