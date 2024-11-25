using Microsoft.AspNetCore.Builder;
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
        //services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
        //{
        //    var libraryPath = Path.GetFullPath(
        //        Path.Combine(Directory.GetCurrentDirectory(), "..", "MyClassLib"));

        //    options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
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
