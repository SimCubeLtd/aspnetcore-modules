using Simcube.AspNetCore.Modules.Microsoft.Interfaces;

namespace Simcube.AspNetCore.Modules.Microsoft.Base;

public abstract class ModuleBase : IModule
{
    public virtual IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public virtual IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        return endpoints;
    }
}