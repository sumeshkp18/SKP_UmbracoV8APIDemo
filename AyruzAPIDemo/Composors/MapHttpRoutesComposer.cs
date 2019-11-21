using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace AyruzAPIDemo.Composors
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MapHttpRoutesComposer : ComponentComposer<MapHttpRoutesComponent>
    {
        // nothing needed to be done here!
    }
    public class MapHttpRoutesComponent : IComponent
    {
        // initialize: runs once when Umbraco starts
        public void Initialize()
        {
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));
            GlobalConfiguration.Configuration.Initializer(GlobalConfiguration.Configuration);
        }

        public void Terminate()
        {

        }
    }
}