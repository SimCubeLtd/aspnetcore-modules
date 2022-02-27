# Simcube.AspNetCore.Modules
## _Simple Module Support To Facilitate in Minimal Api Vertical Slicing_

Organize your project by domain, not technical slices!

Simple module support, nothing else, no extra bloat.

## Usage
Create a module
```csharp
public class InfoModule: IModule
{
    public IServiceCollection RegisterModules(IServiceCollection services)
    {
        services.AddSingleton(new InfoConfig());
        
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/info", () => {
            
        });
        endpoints.MapPost("/info", () => {
            ...
        });
        
        return endpoints;
    }
}
```
Register Modules, and Endpoints in App builder creation using the extension methods:
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.RegisterModules();

var app = builder.Build();
app.MapModuleEndpoints();

app.Run();
```
## Sample
See the Sample project [here](https://github.com/SimCubeLtd/aspnetcore-modules/src/Simcube.AspNetCore.Modules.Sample)

## License

MIT

**Free Software, Hell Yeah!**