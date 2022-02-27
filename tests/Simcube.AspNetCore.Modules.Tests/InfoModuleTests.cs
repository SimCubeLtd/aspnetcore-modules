using Simcube.AspNetCore.Modules.Sample.Modules.InfoModule.Models;

#nullable disable

namespace Simcube.AspNetCore.Modules.Tests;

[TestFixture]
public class InfoModuleTests
{
    private WebApplicationFactory<Program> _factory;

    [OneTimeSetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [Test]
    public void ModuleServices_RegisteredSuccessfully()
    {
        var infoConfigInstance = _factory.Services.GetRequiredService<InfoConfig>();
        infoConfigInstance.Should().NotBeNull();
        infoConfigInstance.InfoValue.Should().Be("Some Info");
    }

    [Test]
    public async Task InfoGet_SuccessfullyRegisteredEndpoint()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/info/123");
        response.EnsureSuccessStatusCode();
        var result = JsonSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
        result.Should().Be(123);
    }

    [Test]
    public async Task InfoPost_SuccessfullyRegisteredEndpoint()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/info", new InfoRequest(123));

        response.EnsureSuccessStatusCode();
        var result = JsonSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
        result.Should().Be(123);
    }

    [Test]
    public async Task TestInfo_EndpointNotRegistered()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/info/info/123");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}