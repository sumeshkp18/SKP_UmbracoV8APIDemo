using AyruzAPIDemo.Models;
using System.Collections.Generic;

namespace AyruzAPIDemo.Services.Interfaces
{
    public interface IShopService
    {
        IEnumerable<Shop> GetAll();
        IEnumerable<Shop> ByMasterCategory(string masterCategory);
        IEnumerable<Shop> BySubCategory(string subCategory);
    }
}