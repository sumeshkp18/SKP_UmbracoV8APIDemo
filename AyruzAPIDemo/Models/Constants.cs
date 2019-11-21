using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyruzAPIDemo.Models
{
    public static class NodeAliasConstants
    {
        public const string Home = "home";
        public const string MasterCategory = "masterCategory";
        public const string Shop = "shop";
        public const string SubCategory = "subCategory";
    }

    public static class ShopPropertyAliasConstants
    {        
        public const string SubCategory = "category";
    }
    public static class SubCategoryPropertyAliasConstants
    {
        public const string MasterCategory = "mainCategory";
    }
}