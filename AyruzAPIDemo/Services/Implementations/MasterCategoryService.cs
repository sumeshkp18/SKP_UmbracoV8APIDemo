using AyruzAPIDemo.Models;
using AyruzAPIDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace AyruzAPIDemo.Services.Implementations
{
    public class MasterCategoryService : IMasterCategoryService
    {
        private readonly UmbracoHelper _umbraco;
        public MasterCategoryService(UmbracoHelper umbraco)
        {
            _umbraco = umbraco;
        }

        public IEnumerable<MasterCategory> GetAll()
        {
            var cachedHomeNode = _umbraco.ContentAtRoot();

            if (cachedHomeNode != null)
            {
                var masterCategories = cachedHomeNode.DescendantsOrSelfOfType(NodeAliasConstants.MasterCategory);
                if (masterCategories.IsNotNullOrEmpty())
                {
                    return masterCategories.Select(x => new MasterCategory(x));
                }
            }
            return null;
        }
    }
}