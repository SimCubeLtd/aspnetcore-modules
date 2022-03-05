namespace Simcube.AspNetCore.Modules.Microsoft.Interfaces;

/// <summary>
/// Represents a configurable application module.
/// A Module is a vertical slice of an applications design.
/// </summary>
public interface IModule
{
    /// <summary>
    /// Register the collection within the service collection, and ultimately the service provider.
    /// </summary>
    /// <param name="services">The service collection to register in</param>
    /// <returns>The provided service collection, with the module registered in it.</returns>
    IServiceCollection RegisterModule(IServiceCollection services);

    /// <summary>
    /// Register the collection within the service collection, and ultimately the service provider.
    /// </summary>
    /// <param name="services">The service collection to register in</param>
    /// <param name="configuration">Configuration instance to use in Registration</param>
    /// <returns>The provided service collection, with the module registered in it.</returns>
    IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration);

    /// <summary>
    /// Map the endpoints for the module.
    /// </summary>
    /// <param name="endpoints">The endpoints builder instance.</param>
    /// <returns>The endpoints builder instance, with the module endpoints successfully registered.</returns>
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}