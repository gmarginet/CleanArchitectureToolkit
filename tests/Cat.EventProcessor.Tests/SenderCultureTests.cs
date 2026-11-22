using System.Globalization;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class SenderCultureTests
{
    private CultureInfo _originalCulture = null!;
    private CultureInfo _originalUICulture = null!;
    private string? _handlerCulture;
    private string? _handlerUICulture;

    [SetUp]
    public void SetUp()
    {
        _originalCulture = CultureInfo.CurrentCulture;
        _originalUICulture = CultureInfo.CurrentUICulture;
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        CultureInfo.CurrentUICulture = new CultureInfo("en-US");
        _handlerCulture = null;
        _handlerUICulture = null;
    }

    [TearDown]
    public void TearDown()
    {
        CultureInfo.CurrentCulture = _originalCulture;
        CultureInfo.CurrentUICulture = _originalUICulture;
    }

    private async Task ReceiveAsync(bool apply, string? culture)
    {
        var processor = new FakeServiceRequestProcessor
        {
            Respond = _ =>
            {
                _handlerCulture = CultureInfo.CurrentCulture.Name;
                _handlerUICulture = CultureInfo.CurrentUICulture.Name;
                return CatResponse.Ok();
            }
        };
        var services = new ServiceCollection();
        services.AddScoped<ICatServiceRequestProcessor>(_ => processor);
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), builder =>
        {
            builder.Receive<OrderPlaced>();
            if (apply)
            {
                builder.ApplySenderCulture();
            }
        });
        using var provider = services.BuildServiceProvider();

        var message = new CatIncomingMessage
        {
            Body = Json.Of(new { orderNumber = "ORD-1" }),
            ContentType = "application/json",
            MessageId = "message-1"
        };
        if (culture != null)
        {
            message.Properties[CatMessageProperties.Culture] = culture;
        }

        await provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), message);
    }

    [Test]
    public async Task Receive_SetsBothCulturesOfTheSenderForTheHandlerWhenTheOptionIsOn()
    {
        await ReceiveAsync(apply: true, culture: "nl-BE");

        Assert.That(_handlerCulture, Is.EqualTo("nl-BE"));
        Assert.That(_handlerUICulture, Is.EqualTo("nl-BE"));
    }

    [Test]
    public async Task Receive_PutsTheOldCultureBackAfterTheHandling()
    {
        await ReceiveAsync(apply: true, culture: "nl-BE");

        Assert.That(CultureInfo.CurrentCulture.Name, Is.EqualTo("en-US"));
        Assert.That(CultureInfo.CurrentUICulture.Name, Is.EqualTo("en-US"));
    }

    [Test]
    public async Task Receive_IgnoresTheCultureWhenTheOptionIsOff()
    {
        await ReceiveAsync(apply: false, culture: "nl-BE");

        Assert.That(_handlerUICulture, Is.EqualTo("en-US"));
    }

    [Test]
    public async Task Receive_KeepsTheDefaultCultureForAMessageWithoutTheProperty()
    {
        await ReceiveAsync(apply: true, culture: null);

        Assert.That(_handlerUICulture, Is.EqualTo("en-US"));
    }

    [Test]
    public async Task Receive_KeepsTheDefaultCultureForAnUnknownCultureName()
    {
        await ReceiveAsync(apply: true, culture: "not a culture!");

        Assert.That(_handlerUICulture, Is.EqualTo("en-US"));
    }
}
