using AyruzAPIDemo.Services.Interfaces;
using Umbraco.Core.Composing;
using Umbraco.Core;
using AyruzAPIDemo.Services.Implementations;

namespace AyruzAPIDemo.Composors
{
    public class DependencyInjection : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IMasterCategoryService, MasterCategoryService>();
            composition.Register<ISubCategoryService, SubCategoryService>();
            composition.Register<IShopService, ShopService>();
        }
    }
}