using Cat.Messaging.Abstractions;
using Cat.Messaging.Extensions;
using Cat.Messaging.Outbox;
using Cat.Messaging.Outbox.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.Tests;

[TestFixture]
public class OutboxTests
{
    private FakeTransport _transport = null!;
    private InMemoryOutboxStore _store = null!;
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _transport = new FakeTransport();
        _store = new InMemoryOutboxStore();

        var services = new ServiceCollection();
        services.AddSingleton<ICatMessageTransport>(_transport);
        services.AddSingleton<ICatOutboxStore>(_store);
        services.AddCatMessagingModule();
        services.AddCatMessagingOutbox();
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown() => _provider.Dispose();

    [Test]
    public async Task Sender_StoresTheMessageAndDoesNotSendIt()
    {
        using var scope = _provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ICatMessageSender>();

        await sender.PublishAsync(new OrderPlaced());

        Assert.That(_store.Items, Has.Count.EqualTo(1));
        Assert.That(_transport.Sent, Is.Empty);
    }

    [Test]
    public async Task OutboxSender_SendsPendingMessagesOnceAndMarksThemSent()
    {
        _store.Items.Add(new StoredItem { Id = Guid.NewGuid(), Message = new CatOutgoingMessage { EntityName = "OrderPlaced" } });
        _store.Items.Add(new StoredItem { Id = Guid.NewGuid(), Message = new CatOutgoingMessage { EntityName = "ReserveStock" } });
        var outboxSender = CreateOutboxSender();

        var first = await outboxSender.SendPendingAsync(CancellationToken.None);
        var second = await outboxSender.SendPendingAsync(CancellationToken.None);

        Assert.That(first, Is.EqualTo(2));
        Assert.That(second, Is.EqualTo(0));
        Assert.That(_transport.Sent.Select(m => m.EntityName), Is.EqualTo(new[] { "OrderPlaced", "ReserveStock" }));
    }

    [Test]
    public async Task OutboxSender_LeavesAMessagePendingWhenTheTransportFails()
    {
        _store.Items.Add(new StoredItem { Id = Guid.NewGuid(), Message = new CatOutgoingMessage { EntityName = "OrderPlaced" } });
        var services = new ServiceCollection();
        services.AddSingleton<ICatMessageTransport>(new FailingTransport());
        services.AddSingleton<ICatOutboxStore>(_store);
        using var provider = services.BuildServiceProvider();
        var outboxSender = new OutboxSender(provider.GetRequiredService<IServiceScopeFactory>(),
            Options.Create(new CatOutboxOptions()), NullLogger<OutboxSender>.Instance);

        await Assert.ThrowsAsync<InvalidOperationException>(() => outboxSender.SendPendingAsync(CancellationToken.None));
        Assert.That(_store.Items.Single().Sent, Is.False);
    }

    private OutboxSender CreateOutboxSender() =>
        new(_provider.GetRequiredService<IServiceScopeFactory>(), Options.Create(new CatOutboxOptions()), NullLogger<OutboxSender>.Instance);

    private sealed class FailingTransport : ICatMessageTransport
    {
        public Task SendAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default) =>
            throw new InvalidOperationException("The bus is down.");
    }

    private sealed class InMemoryOutboxStore : ICatOutboxStore
    {
        public List<StoredItem> Items { get; } = [];

        public Task AddAsync(CatOutgoingMessage message, CancellationToken cancellationToken = default)
        {
            Items.Add(new StoredItem { Id = Guid.NewGuid(), Message = message });
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<CatOutboxItem>> GetPendingAsync(int maxCount, CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<CatOutboxItem>>(Items.Where(i => !i.Sent).Take(maxCount).Cast<CatOutboxItem>().ToList());

        public Task MarkSentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            Items.Single(i => i.Id == id).Sent = true;
            return Task.CompletedTask;
        }
    }

    public class StoredItem : CatOutboxItem
    {
        public bool Sent { get; set; }
    }
}
