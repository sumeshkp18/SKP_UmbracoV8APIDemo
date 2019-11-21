using AyruzAPIDemo.Models;
using AyruzAPIDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace AyruzAPIDemo.Services.Implementations
{
    public class ShopService : IShopService
    {
        private readonly UmbracoHelper _umbraco;
        private readonly ISubCategoryService _subCategoryService;
        public ShopService(UmbracoHelper umbraco, ISubCategoryService subCategoryService)
        {
            _umbraco = umbraco;
            _subCategoryService = subCategoryService;
        }
        /// <summary>
        /// Get all Shops
        /// </summary>
        /// <returns>Returns All published Shops</returns>
        public IEnumerable<Shop> GetAll()
        {
            var cachedHomeNode = _umbraco.ContentAtRoot();
            if (cachedHomeNode != null)
            {
                var shops = cachedHomeNode.DescendantsOrSelfOfType(NodeAliasConstants.Shop);
                if (shops.IsNotNullOrEmpty())
                {
                    return shops.Select(x => new Shop(x));
                }
            }
            return null;
        }

        /// <summary>
        /// Get Shop By Master Category
        /// </summary>
        /// <param name="masterCategory"></param>
        /// <returns>Returns All shops which linked with the provided master category</returns>
        public IEnumerable<Shop> ByMasterCategory(string masterCategory)
        {
            List<Shop> shops = null;

            // Get all Sub Categories
            var allSubCategory = _subCategoryService.GetAll();
            if (allSubCategory.IsNotNullOrEmpty())
            {
                // Filter out all Sub category corresponding to the master category
                var subcategoryCorrespondingToMaster = allSubCategory.Where(x => x.MasterCategory?.Clean() == masterCategory?.Clean());
                if (subcategoryCorrespondingToMaster.IsNotNullOrEmpty())
                {

                    // Get products which is selected to the filtered sub category
                    foreach (var subCategory in subcategoryCorrespondingToMaster)
                    {
                        var filteredShops = BySubCategory(subCategory.Name);

                        if (filteredShops.IsNotNullOrEmpty())
                        {
                            if (shops == null)
                            {
                                shops = new List<Shop>();
                            }

                            shops.AddRange(filteredShops);

                        }
                    }
                }
            }
            // Show distinct Result
            return shops?.DistinctBy(x => x.Id);
        }

        /// <summary>
        /// Get Shop By Sub Category
        /// </summary>
        /// <param name="subCategory"></param>
        /// <returns>Returns All shops which linked with the provided sub category</returns>
        public IEnumerable<Shop> BySubCategory(string subCategory)
        {
            // Get All Shops
            var allShops = GetAll();
            if (allShops.IsNotNullOrEmpty())
            {
                // Return Shops which is linked with particular sub category
                return allShops.Where(shop => shop.SubCategories?.Any(category => category?.Clean() == subCategory?.Clean()) == true);
            }
            return null;
        }
    }
}