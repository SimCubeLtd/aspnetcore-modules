using Simcube.AspNetCore.Modules.Microsoft.Base;
using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Endpoints;
using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.InfoModule;

public class InfoModule : ModuleBase
{
    public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new InfoConfig());

        return services;
    }

    public override IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/info/{infoId}", GetInfo.Handle);
        endpoints.MapPost("/info", PostInfo.Handle);

        return endpoints;
    }
}