using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace AyruzAPIDemo.Models
{
    public class MasterCategory : NodeBase
    {
        public MasterCategory() { }
        public MasterCategory(IPublishedContent content) {
            this.Id = content.Id;
            this.Name = content.Name;
        }
    }
}