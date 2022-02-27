using Simcube.AspNetCore.Modules.Sample.Modules.TestModule.Models;

#nullable disable

namespace Simcube.AspNetCore.Modules.Tests;

[TestFixture]
public class TestModuleTests
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
        var testConfigInstance = _factory.Services.GetRequiredService<TestConfig>();
        testConfigInstance.Should().NotBeNull();
        testConfigInstance.TestValue.Should().Be("A Test");
    }

    [Test]
    public async Task TestGet_SuccessfullyRegisteredEndpoint()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/tests/123");
        response.EnsureSuccessStatusCode();
        var result = JsonSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
        result.Should().Be(123);
    }

    [Test]
    public async Task TestPost_SuccessfullyRegisteredEndpoint()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/tests", new TestRequest(123));

        response.EnsureSuccessStatusCode();
        var result = JsonSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
        result.Should().Be(123);
    }

    [Test]
    public async Task TestGet_EndpointNotRegistered()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/tests/tests/123");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}