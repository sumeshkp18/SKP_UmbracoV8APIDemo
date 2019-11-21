using AyruzAPIDemo.Models;
using AyruzAPIDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;

namespace AyruzAPIDemo.Services.Implementations
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly UmbracoHelper _umbraco;
        public SubCategoryService(UmbracoHelper umbraco)
        {
            _umbraco = umbraco;
        }

        public IEnumerable<SubCategory> GetAll()
        {
            var cachedHomeNode = _umbraco.ContentAtRoot();
            if (cachedHomeNode != null)
            {
                var subCategories = cachedHomeNode.DescendantsOrSelfOfType(NodeAliasConstants.SubCategory);
                if (subCategories != null && subCategories.Any())
                {
                    return subCategories.Select(x => new SubCategory(x));
                }
            }
            return null;
        }
    }
}