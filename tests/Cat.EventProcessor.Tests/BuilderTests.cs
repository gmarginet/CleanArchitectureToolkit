using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void Receive_DeclaresTheMessageTypesWithTheirSettingsFromCode()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), builder => builder
            .Receive<OrderPlaced>(options => options.MaxConcurrentCalls = 4)
            .Receive<ReserveStock>());
        using var provider = services.BuildServiceProvider();

        var registrations = provider.GetRequiredService<ICatReceiveRegistry>().Registrations;

        Assert.That(registrations.Select(r => r.MessageType), Is.EqualTo(new[] { typeof(OrderPlaced), typeof(ReserveStock) }));
        Assert.That(registrations[0].Options.MaxConcurrentCalls, Is.EqualTo(4));
        Assert.That(registrations[1].Options.MaxConcurrentCalls, Is.Null);
    }

    [Test]
    public void Configuration_WinsOverTheCode()
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["CatEventProcessor:Messages:OrderPlaced:MaxConcurrentCalls"] = "9",
            ["CatEventProcessor:Messages:OrderPlaced:FailureOverrides:NotFound"] = "Complete"
        }).Build();
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatEventProcessor(configuration, builder => builder.Receive<OrderPlaced>(options => options.MaxConcurrentCalls = 4));
        using var provider = services.BuildServiceProvider();

        var options = provider.GetRequiredService<ICatReceiveRegistry>().Registrations.Single().Options;

        Assert.That(options.MaxConcurrentCalls, Is.EqualTo(9));
        Assert.That(options.FailureOverrides["NotFound"], Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public void Receive_ThrowsWhenAMessageTypeIsDeclaredTwice()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        Assert.Throws<InvalidOperationException>(() => services.AddCatEventProcessor(new ConfigurationBuilder().Build(),
            builder => builder.Receive<OrderPlaced>().Receive<OrderPlaced>()));
    }
}
