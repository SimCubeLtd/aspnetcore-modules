using System.Reflection;
using Simcube.AspNetCore.Modules.Microsoft.Interfaces;

namespace Simcube.AspNetCore.Modules.Microsoft.Extensions;

public static class ModuleExtensions
{
    public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
    {
        foreach (var module in DiscoverModules())
        {
            module.RegisterModule(builder.Services, builder.Configuration);

            builder.Services.AddSingleton(module);
        }

        return builder;
    }

    public static WebApplication MapModuleEndpoints(this WebApplication app)
    {
        foreach (var module in app.Services.GetServices<IModule>())
        {
            module.MapEndpoints(app);
        }

        return app;
    }

    public static WebApplication ExecuteModulePreRunActions(this WebApplication app)
    {
        foreach (var module in app.Services.GetServices<IModule>())
        {
            module.ExecuteModulePreRunActions(app);
        }

        return app;
    }

    private static IEnumerable<IModule> DiscoverModules()
    {
        var modules = new List<IModule>();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            modules.AddRange(GetModulesInAssembly(assembly));
        }

        return modules;

    }

    private static IEnumerable<IModule> GetModulesInAssembly(Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(p => p.IsClass && !p.IsAbstract && p.IsAssignableTo(typeof(IModule)))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();
    }
}