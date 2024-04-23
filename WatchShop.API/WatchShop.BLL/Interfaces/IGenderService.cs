using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.BLL.Interfaces
{
    public interface IGenderService
    {
        public IEnumerable<GenderContract> GetAllGenders();
        public GenderContract GetGenderById(Guid id);
        public GenderContract GetGenderByName(string name);
    }
}
