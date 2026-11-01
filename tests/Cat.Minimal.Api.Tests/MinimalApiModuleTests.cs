using Cat.Minimal.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DiServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;

namespace Cat.Minimal.Api.Tests;

[TestFixture]
public class MinimalApiModuleTests
{
    [Test]
    public void AddCatMinimalApiModule_ReturnsTheSameServiceCollection()
    {
        var services = new DiServiceCollection();

        var result = services.AddCatMinimalApiModule();

        Assert.That(result, Is.SameAs(services));
    }

    [Test]
    public void AddCatMinimalApiModule_RegistersTheExceptionHandler()
    {
        var services = new DiServiceCollection();
        services.AddCatMinimalApiModule();

        Assert.That(services.Any(s => s.ServiceType == typeof(IExceptionHandler)), Is.True);
    }

    [Test]
    public void AddCatMinimalApiModule_RegistersTheProblemDetailsServices()
    {
        var services = new DiServiceCollection();
        services.AddCatMinimalApiModule();

        Assert.That(services.Any(s => s.ServiceType == typeof(IProblemDetailsService)), Is.True);
    }

    [Test]
    public void AddCatMinimalApiModule_MakesBindingFailuresThrowInEveryEnvironment()
    {
        var services = new DiServiceCollection();
        services.AddCatMinimalApiModule();

        using var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<RouteHandlerOptions>>().Value;

        Assert.That(options.ThrowOnBadRequest, Is.True);
    }

    [Test]
    public async Task UseCatMinimalApiModule_ReturnsTheSameApplicationBuilder()
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = "Production" });
        builder.Logging.ClearProviders();
        builder.Services.AddCatMinimalApiModule();
        await using var app = builder.Build();

        var result = ((IApplicationBuilder)app).UseCatMinimalApiModule();

        Assert.That(result, Is.SameAs(app));
    }
}
