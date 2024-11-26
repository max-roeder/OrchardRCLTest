using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModule
{
    internal class EmbeddedViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return viewLocations.Concat(new[]
            {
                "/Views/Shared/Components/{0}/{1}.cshtml", // Standard ViewComponent location
                "/EmbeddedViews/{0}.cshtml",               // Custom location if needed
                "/MyClassLib.Views.Shared.Components.MyRCL.default.cshtml"
            });
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            
        }
    }
}
