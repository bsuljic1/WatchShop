using System;
using System.Collections.Generic;
using WatchShop.Contracts;

namespace WatchShop.DAL.Interfaces
{
    public interface IGenderRepository
    {
        public IEnumerable<GenderContract> GetAllGenders();
        public GenderContract GetGenderById(Guid id);
        public GenderContract GetGenderByName(string name);
    }
}
