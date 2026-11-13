using Cat.Messaging.Abstractions;
using Cat.Sql.Cdc.Abstractions;
using Cat.Sql.Cdc.Extensions;
using Cat.Sql.Cdc.Messaging;
using Cat.Sql.Cdc.Messaging.Extensions;
using Cat.UnitTesting.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cat.Sql.Cdc.Tests;

[TestFixture]
public class CatCdcRegistrationTests
{
    private class BookPriceChanged : CatEventMessage
    {
        public string Isbn { get; init; } = "";
    }

    private class ForeignMessage : ICatEventMessage
    {
        public Guid MessageId { get; } = Guid.NewGuid();
        public Guid CorrelationId { get; } = Guid.NewGuid();
        public DateTimeOffset OccurredAt { get; } = DateTimeOffset.UtcNow;
    }

    private static CatChange Change() => new()
    {
        Table = "dbo_BookPrice",
        Operation = CatChangeOperation.Update,
        Lsn = Lsn.Of(5),
        SequenceValue = Lsn.Of(1),
        TransactionId = [0xAB, 0xCD],
        TransactionTime = new DateTimeOffset(2026, 1, 2, 3, 4, 5, TimeSpan.Zero),
        Keys = new Dictionary<string, object?> { ["Id"] = 1 },
        Old = new Dictionary<string, object?> { ["Price"] = 10m },
        New = new Dictionary<string, object?> { ["Price"] = 12m }
    };

    private static (CatMessagingChangeSink Sink, FakeMessageSender Sender) CreateSink()
    {
        var sender = new FakeMessageSender();
        var services = new ServiceCollection();
        services.AddScoped<ICatMessageSender>(_ => sender);
        var provider = services.BuildServiceProvider();
        return (new CatMessagingChangeSink(provider.GetRequiredService<IServiceScopeFactory>()), sender);
    }

    [Test]
    public async Task Sink_ChangeWithoutMapping_PublishesTheDefaultMessage()
    {
        var (sink, sender) = CreateSink();
        var change = Change();

        await sink.SendAsync(change, change);

        var message = sender.Of<CatCdcChangeMessage>().Single();
        Assert.That(message.MessageId, Is.EqualTo(change.MessageId));
        Assert.That(message.Table, Is.EqualTo("dbo_BookPrice"));
        Assert.That(message.Operation, Is.EqualTo(CatChangeOperation.Update));
        Assert.That(message.TransactionId, Is.EqualTo("ABCD"));
        Assert.That(message.New!["Price"], Is.EqualTo(12m));
        Assert.That(message.Old!["Price"], Is.EqualTo(10m));
    }

    [Test]
    public async Task Sink_MappedMessage_GetsTheIdOfTheChange()
    {
        var (sink, sender) = CreateSink();
        var change = Change();

        await sink.SendAsync(change, new BookPriceChanged { Isbn = "1" });

        Assert.That(sender.Of<ICatEventMessage>().Single().MessageId, Is.EqualTo(change.MessageId));
    }

    [Test]
    public async Task Sink_MessageThatCannotTakeTheId_Throws()
    {
        var (sink, _) = CreateSink();

        await Assert.ThrowsAsync<InvalidOperationException>(() => sink.SendAsync(Change(), new ForeignMessage()));
    }

    [Test]
    public async Task Sink_MessageThatIsNotAnEvent_Throws()
    {
        var (sink, _) = CreateSink();

        await Assert.ThrowsAsync<InvalidOperationException>(() => sink.SendAsync(Change(), "text"));
    }

    [Test]
    public void AddTable_NameWithSqlCharacters_Throws()
    {
        var builder = new CatCdcBuilder();

        Assert.Throws<ArgumentException>(() => builder.AddTable("dbo_Book]; DROP TABLE x;--"));
    }

    [Test]
    public void AddTable_SameTableTwice_Throws()
    {
        var builder = new CatCdcBuilder().AddTable("dbo_Book");

        Assert.Throws<InvalidOperationException>(() => builder.AddTable("DBO_BOOK"));
    }

    [Test]
    public void AddTable_WithoutMapping_Throws()
    {
        var builder = new CatCdcBuilder();

        Assert.Throws<InvalidOperationException>(() => builder.AddTable<BookPriceChanged>("dbo_Book", _ => { }));
    }

    [Test]
    public void AddCatSqlCdc_RegistersTheHostedServiceAndBindsTheSettings()
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["CatSqlCdc:ConnectionString"] = "Server=x",
            ["CatSqlCdc:BatchSize"] = "50",
            ["CatSqlCdc:OnRetentionGap"] = "SkipToOldest"
        }).Build();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddCatSqlCdcMessaging();
        services.AddScoped<ICatMessageSender, FakeMessageSender>();

        services.AddCatSqlCdc(configuration, b => b.AddTable("dbo_Book"));
        var provider = services.BuildServiceProvider();

        var settings = provider.GetRequiredService<CatCdcSettings>();
        Assert.That(settings.BatchSize, Is.EqualTo(50));
        Assert.That(settings.OnRetentionGap, Is.EqualTo(CatCdcGapBehavior.SkipToOldest));
        Assert.That(provider.GetServices<IHostedService>().OfType<CatCdcService>(), Has.Exactly(1).Items);
        Assert.That(provider.GetRequiredService<ICatChangeSink>(), Is.TypeOf<CatMessagingChangeSink>());
    }

    [Test]
    public void AddCatSqlCdc_BatchSizeBelowOne_Throws()
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?> { ["CatSqlCdc:BatchSize"] = "0" }).Build();

        Assert.Throws<InvalidOperationException>(() => new ServiceCollection().AddCatSqlCdc(configuration, _ => { }));
    }

    [Test]
    public void SqlServerDatabase_WithoutConnectionString_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => new SqlServerCdcDatabase(new CatCdcSettings()));
    }

    [Test]
    public void SqlServerDatabase_SchemaWithSqlCharacters_Throws()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new SqlServerCdcDatabase(new CatCdcSettings { ConnectionString = "Server=x", Schema = "x]; DROP TABLE y;--" }));
    }
}
