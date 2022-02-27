using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Endpoints;
using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Models;

namespace Simcube.AspNetCore.Modules.Sample.Modules.TestModule;

public class TestModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton(new TestConfig());

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/tests/{testId}", GetTest.Handle);
        endpoints.MapPost("/tests", PostTest.Handle);

        return endpoints;
    }
}