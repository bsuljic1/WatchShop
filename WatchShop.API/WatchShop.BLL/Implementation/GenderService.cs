using System;
using System.Collections.Generic;
using WatchShop.BLL.Interfaces;
using WatchShop.Contracts;
using WatchShop.DAL.Interfaces;

namespace WatchShop.BLL.Implementation
{
    public class GenderService : IGenderService
    {
        private IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public IEnumerable<GenderContract> GetAllGenders()
        {
            return _genderRepository.GetAllGenders();
        }

        public GenderContract GetGenderById(Guid id)
        {
            return _genderRepository.GetGenderById(id);
        }

        public GenderContract GetGenderByName(string name)
        {
            return _genderRepository.GetGenderByName(name);
        }
    }
}
