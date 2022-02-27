using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Endpoints;
using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.InfoModule;

public class InfoModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton(new InfoConfig());

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/info/{infoId}", GetInfo.Handle);
        endpoints.MapPost("/info", PostInfo.Handle);

        return endpoints;
    }
}