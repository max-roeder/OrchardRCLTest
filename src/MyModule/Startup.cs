using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using OrchardCore.Modules;

namespace MyModule;

public sealed class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {

        var assembly = typeof(MyClassLib.ViewComponents.MyRCLViewComponent).Assembly;

        var resourceNames = assembly.GetManifestResourceNames();

        services.AddMvc()
            .ConfigureApplicationPartManager(apm =>
            {
                apm.ApplicationParts.Add(new AssemblyPart(assembly));
            })
            .AddRazorRuntimeCompilation(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assembly));
            });


        //services.Configure<RazorViewEngineOptions>(options =>
        //{
        //    options.ViewLocationExpanders.Add(new EmbeddedViewLocationExpander());
        //});

    }

    public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
    {
        routes.MapAreaControllerRoute(
            name: "HomeRoute",
            areaName: "MyModule",
            pattern: "/",
            defaults: new { controller = "Home", action = "Index" }
            );

        routes.MapAreaControllerRoute(
            name: "SecondPageRoute",
            areaName: "MyModule",
            pattern: "/secondPage",
            defaults: new { controller = "Home", action = "SecondPage" }
            );
    }
}
