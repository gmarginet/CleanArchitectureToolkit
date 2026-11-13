using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Messaging.Tests;

[TestFixture]
public class TokenSenderTests
{
    private FakeTransport _transport = null!;

    private ServiceProvider Build(ICatTokenProvider? provider)
    {
        _transport = new FakeTransport();
        var services = new ServiceCollection();
        services.AddSingleton<ICatMessageTransport>(_transport);
        if (provider != null)
        {
            services.AddSingleton(provider);
        }

        services.AddCatMessagingModule();
        return services.BuildServiceProvider();
    }

    [Test]
    public async Task Send_PutsTheTokenOfTheCurrentUserInTheAuthorizationProperty()
    {
        using var root = Build(new FakeTokenProvider());
        using var scope = root.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatMessageSender>().SendAsync(new ReserveStock { Quantity = 1 });

        Assert.That(_transport.Sent.Single().Properties[CatMessageProperties.Authorization], Is.EqualTo("Bearer user-token"));
    }

    [Test]
    public async Task Send_AsksForTheTokenOfTheSystemForAScheduledMessage()
    {
        using var root = Build(new FakeTokenProvider());
        using var scope = root.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatMessageSender>()
            .SendAsync(new ReserveStock { Quantity = 1 }, DateTimeOffset.UtcNow.AddHours(24));

        Assert.That(_transport.Sent.Single().Properties[CatMessageProperties.Authorization], Is.EqualTo("Bearer system-token"));
    }

    [Test]
    public async Task Send_AddsNoPropertyWithoutAProvider()
    {
        using var root = Build(null);
        using var scope = root.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatMessageSender>().SendAsync(new ReserveStock { Quantity = 1 });

        Assert.That(_transport.Sent.Single().Properties, Does.Not.ContainKey(CatMessageProperties.Authorization));
    }

    [Test]
    public async Task Send_AddsNoPropertyWhenTheProviderGivesNoToken()
    {
        using var root = Build(new FakeTokenProvider(returnNothing: true));
        using var scope = root.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatMessageSender>().SendAsync(new ReserveStock { Quantity = 1 });

        Assert.That(_transport.Sent.Single().Properties, Does.Not.ContainKey(CatMessageProperties.Authorization));
    }

    private sealed class FakeTokenProvider(bool returnNothing = false) : ICatTokenProvider
    {
        public Task<string?> GetTokenAsync(CatTokenSubject subject, CancellationToken cancellationToken = default) =>
            Task.FromResult<string?>(returnNothing ? null : subject == CatTokenSubject.System ? "system-token" : "user-token");
    }
}
