var builder = WebApplication.CreateBuilder(args);

builder.RegisterModules();

var app = builder.Build();
app.MapModuleEndpoints();

app.Run();