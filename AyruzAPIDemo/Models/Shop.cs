using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace AyruzAPIDemo.Models
{
    public class Shop : NodeBase
    {
        public Shop() { }
        public Shop(IPublishedContent content)
        {
            this.Id = content.Id;
            this.Name = content.Name;

            //Get SubCategories
            var selectedCategories = content.Value<IEnumerable<IPublishedContent>>(ShopPropertyAliasConstants.SubCategory);
            if(selectedCategories!=null && selectedCategories.Any())
            {
                this.SubCategories = selectedCategories.Select(category => category.Name);
            }
           
        }
        public IEnumerable<string> SubCategories { get; set; }
    }
}