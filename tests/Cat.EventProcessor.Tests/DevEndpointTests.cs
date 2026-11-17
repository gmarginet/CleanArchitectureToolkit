using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Minimal.Api.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class DevEndpointTests
{
    private static WebApplication CreateApp(string environment)
    {
        var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = environment });
        builder.Services.AddScoped<ICatServiceRequestProcessor>(_ => new FakeServiceRequestProcessor());
        // The test maps endpoints only, so there is no message transport and nothing is resolved.
        builder.Host.UseDefaultServiceProvider(options => options.ValidateOnBuild = false);
        builder.Services.AddCatMessagingModule();
        builder.Services.AddCatEventProcessor(builder.Configuration, events => events.Receive<OrderPlaced>());
        return builder.Build();
    }

    [Test]
    public void Development_MapsTheEndpointsWithTheDevGroupName()
    {
        var app = CreateApp("Development");

        var group = app.MapCatEventProcessor();

        Assert.That(group, Is.Not.Null);
        var endpoints = ((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints).ToList();
        Assert.That(endpoints, Has.Count.EqualTo(2));
        Assert.That(endpoints.Select(endpoint => endpoint.Metadata.GetMetadata<IEndpointGroupNameMetadata>()?.EndpointGroupName),
            Is.All.EqualTo(Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.DevDocumentName));
    }

    [Test]
    public void CreateMessage_PutsTheAuthorizationHeaderInTheAuthorizationProperty()
    {
        var message = Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.CreateMessage("{}", "Bearer abc");

        Assert.That(message.Properties[CatMessageProperties.Authorization], Is.EqualTo("Bearer abc"));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    public void CreateMessage_WithoutAHeader_HasNoToken(string? header)
    {
        var message = Cat.EventProcessor.Minimal.Api.Extensions.EndpointRouteBuilderExtensions.CreateMessage("{}", header);

        Assert.That(message.Properties, Is.Empty);
    }

    [Test]
    public void OtherEnvironments_MapNothing()
    {
        var app = CreateApp("Production");

        var group = app.MapCatEventProcessor();

        Assert.That(group, Is.Null);
        Assert.That(((IEndpointRouteBuilder)app).DataSources.SelectMany(source => source.Endpoints), Is.Empty);
    }
}
