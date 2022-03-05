using Simcube.AspNetCore.Modules.Microsoft.Base;
using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Endpoints;
using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.TestModule;

public class TestModule : ModuleBase
{
    public override IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new TestConfig());

        return services;
    }

    public override IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/tests/{testId}", GetTest.Handle);
        endpoints.MapPost("/tests", PostTest.Handle);

        return endpoints;
    }
}