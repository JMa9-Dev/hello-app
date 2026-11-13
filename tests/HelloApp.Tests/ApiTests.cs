using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace HelloApp.Tests;

public class ApiTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
{
    [Fact]
    public async Task Root_ReturnsOk()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync(new Uri("/", UriKind.Relative));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task HealthCheck_ReturnsHealthy()
    {
        using var client = factory.CreateClient();

        var body = await client.GetStringAsync(new Uri("/healthz", UriKind.Relative));

        Assert.Equal("Healthy", body);
    }
}
