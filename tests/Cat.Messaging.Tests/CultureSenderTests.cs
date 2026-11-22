using System.Globalization;
using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Messaging.Tests;

[TestFixture]
public class CultureSenderTests
{
    private CultureInfo _originalUICulture = null!;
    private FakeTransport _transport = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _originalUICulture = CultureInfo.CurrentUICulture;
        _transport = new FakeTransport();
        var services = new ServiceCollection();
        services.AddSingleton<ICatMessageTransport>(_transport);
        services.AddCatMessagingModule();
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown()
    {
        CultureInfo.CurrentUICulture = _originalUICulture;
        _provider.Dispose();
    }

    [Test]
    public async Task Send_PutsTheCurrentUICultureInTheCultureProperty()
    {
        CultureInfo.CurrentUICulture = new CultureInfo("nl-BE");

        await _provider.GetRequiredService<ICatMessageSender>().SendAsync(new ReserveStock { Quantity = 1 });

        Assert.That(_transport.Sent.Single().Properties[CatMessageProperties.Culture], Is.EqualTo("nl-BE"));
    }

    [Test]
    public async Task Publish_PutsTheCurrentUICultureInTheCultureProperty()
    {
        CultureInfo.CurrentUICulture = new CultureInfo("en");

        await _provider.GetRequiredService<ICatMessageSender>().PublishAsync(new OrderPlaced());

        Assert.That(_transport.Sent.Single().Properties[CatMessageProperties.Culture], Is.EqualTo("en"));
    }

    [Test]
    public async Task Send_LeavesTheCulturePropertyOutForTheInvariantCulture()
    {
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

        await _provider.GetRequiredService<ICatMessageSender>().SendAsync(new ReserveStock { Quantity = 1 });

        Assert.That(_transport.Sent.Single().Properties.ContainsKey(CatMessageProperties.Culture), Is.False);
    }
}
