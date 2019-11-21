using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace AyruzAPIDemo.Models
{
    public class SubCategory : NodeBase
    {
        public SubCategory() { }
        public SubCategory(IPublishedContent content)
        {
            this.Id = content.Id;
            this.Name = content.Name;

            //Get Master Categories
            var selectedCategory = content.Value<IPublishedContent>(SubCategoryPropertyAliasConstants.MasterCategory);
            if (selectedCategory != null)
            {
                this.MasterCategory = selectedCategory.Name;
            }

        }
        //[JsonIgnore]
        public string MasterCategory { get; set; }
    }
}