using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Inbox.EFCore;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class InboxTests
{
    private FakeStore _store = null!;
    private CountingHandler _inner = null!;
    private InboxDecorator.CatServiceRequestHandler<OrderPlaced> _decorator = null!;

    [SetUp]
    public void SetUp()
    {
        _store = new FakeStore();
        _inner = new CountingHandler();
        _decorator = new InboxDecorator.CatServiceRequestHandler<OrderPlaced>(_inner, _store);
    }

    [Test]
    public async Task NewMessage_GetsARowAndRunsTheHandler()
    {
        using var context = CatMessageContext.Begin("m-1", 1);

        var response = await _decorator.HandleAsync(new OrderPlaced());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_inner.Calls, Is.EqualTo(1));
        Assert.That(_store.Added, Is.EqualTo(new[] { "m-1" }));
    }

    [Test]
    public async Task RepeatedMessage_IsSkippedAndSucceeds()
    {
        _store.Existing.Add("m-1");
        using var context = CatMessageContext.Begin("m-1", 2);

        var response = await _decorator.HandleAsync(new OrderPlaced());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_inner.Calls, Is.EqualTo(0));
        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public async Task RequestWithoutAMessage_PassesStraightOn()
    {
        var response = await _decorator.HandleAsync(new OrderPlaced());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_inner.Calls, Is.EqualTo(1));
        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public void AddCatInbox_MapsTheInboxTableWithTheMessageIdAsKey()
    {
        using var context = new InboxTestContext();

        var entity = context.Model.FindEntityType(typeof(CatInboxMessage));

        Assert.That(entity!.GetTableName(), Is.EqualTo("CatInbox"));
        Assert.That(entity!.FindPrimaryKey()!.Properties.Single().Name, Is.EqualTo(nameof(CatInboxMessage.MessageId)));
    }

    private sealed class FakeStore : ICatInboxStore
    {
        public HashSet<string> Existing { get; } = [];
        public List<string> Added { get; } = [];

        public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default) =>
            Task.FromResult(Existing.Contains(messageId));

        public void Add(string messageId, string messageType) => Added.Add(messageId);
    }

    private sealed class CountingHandler : ICatServiceRequestHandler<OrderPlaced>
    {
        public int Calls { get; private set; }

        public Task<ICatResponse> HandleAsync(OrderPlaced request, CancellationToken cancellationToken = default)
        {
            Calls++;
            return Task.FromResult(CatResponse.Ok());
        }
    }

    private sealed class InboxTestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Server=localhost;Database=Unused;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatInbox();
    }
}
