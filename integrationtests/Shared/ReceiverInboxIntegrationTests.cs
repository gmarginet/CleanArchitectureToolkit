using System.Text.Json;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Inbox.EFCore;
using Cat.EventProcessor.Inbox.EFCore.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EFCore.IntegrationTests;

/// <summary>
/// A row that the handler of <see cref="RecordVisit"/> adds.
/// </summary>
public class Visit
{
    public Guid Id { get; set; }

    public string Note { get; set; } = "";
}

/// <summary>
/// The context of the receiver tests. It holds the inbox and the rows of the handler, so one save writes both.
/// </summary>
public class ReceiverDbContext : DbContext
{
    public ReceiverDbContext(DbContextOptions<ReceiverDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Cat.EventProcessor.Inbox.EFCore.ModelBuilderExtensions.AddCatInbox(modelBuilder);
        modelBuilder.Entity<Visit>(entity =>
        {
            entity.ToTable("Visits");
            entity.HasKey(visit => visit.Id);
            entity.Property(visit => visit.Id).ValueGeneratedNever();
            entity.Property(visit => visit.Note).HasMaxLength(50);
        });
    }
}

/// <summary>
/// The message of the receiver tests. The handler adds a <see cref="Visit"/> with <see cref="VisitId"/>, or with a new id when it is empty.
/// </summary>
public class RecordVisit : CatEventMessage, ICatServiceRequest
{
    public Guid? VisitId { get; set; }

    public string Note { get; set; } = "";
}

/// <summary>
/// Lets a test hold every handler just before its save, until the given number of handlers got there.
/// </summary>
public class HandlerGate
{
    public Barrier? BeforeSave { get; set; }
}

public class RecordVisitHandler : ICatServiceRequestHandler<RecordVisit>
{
    private readonly ReceiverDbContext _dbContext;
    private readonly HandlerGate _gate;

    public RecordVisitHandler(ReceiverDbContext dbContext, HandlerGate gate)
    {
        _dbContext = dbContext;
        _gate = gate;
    }

    public async Task<ICatResponse> HandleAsync(RecordVisit serviceRequest, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<Visit>().Add(new Visit { Id = serviceRequest.VisitId ?? Guid.NewGuid(), Note = serviceRequest.Note });
        _gate.BeforeSave?.SignalAndWait(TimeSpan.FromSeconds(10));
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}

/// <summary>
/// The real receiver, the real service request processor and the real inbox on a real database.
/// The inbox row and the change of the handler must go out in one save, so they commit together or not at all.
/// Both database projects compile this file. A project adds the other part of this class: the base class with its database, and the provider.
/// </summary>
[TestFixture]
public partial class ReceiverInboxIntegrationTests
{
    private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

    private ServiceProvider _provider = null!;
    private HandlerGate _gate = null!;

    [OneTimeSetUp]
    public async Task CreateSchema()
    {
        await using var provider = BuildProvider(new HandlerGate());
        using var scope = provider.CreateScope();
        await scope.ServiceProvider.GetRequiredService<ReceiverDbContext>().Database.EnsureCreatedAsync();
    }

    [SetUp]
    public async Task SetUp()
    {
        _gate = new HandlerGate();
        _provider = BuildProvider(_gate);

        using var scope = _provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ReceiverDbContext>();
        await context.Set<CatInboxMessage>().ExecuteDeleteAsync();
        await context.Set<Visit>().ExecuteDeleteAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        _gate.BeforeSave?.Dispose();
        await _provider.DisposeAsync();
    }

    private ServiceProvider BuildProvider(HandlerGate gate)
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddSingleton(gate);
        services.AddDbContext<ReceiverDbContext>(options => UseDatabase(options, ConnectionString));
        services.AddCatEventProcessorInbox<ReceiverDbContext>();
        services.AddCatServiceRequestsModule(typeof(RecordVisitHandler));
        services.AddCatEventProcessor(new ConfigurationBuilder().Build(), processor => processor
            .Receive<RecordVisit>(options => options.UseInbox = true));
        return services.BuildServiceProvider();
    }

    private Task<CatSettlementResult> ReceiveAsync(string messageId, RecordVisit request)
    {
        var message = new CatIncomingMessage
        {
            Body = JsonSerializer.SerializeToUtf8Bytes(request, Json),
            ContentType = "application/json",
            MessageId = messageId
        };

        return _provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(RecordVisit), message);
    }

    private async Task<int> CountAsync<TEntity>() where TEntity : class
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ReceiverDbContext>().Set<TEntity>().CountAsync();
    }

    [Test]
    public async Task Receive_SavesTheInboxRowAndTheChangeOfTheHandlerTogether()
    {
        var result = await ReceiveAsync("message-1", new RecordVisit { Note = "first" });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
            Assert.That(await CountAsync<Visit>(), Is.EqualTo(1));
            Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Receive_OfTheSameMessageTwice_RunsTheHandlerOnce()
    {
        await ReceiveAsync("message-1", new RecordVisit { Note = "first" });
        var second = await ReceiveAsync("message-1", new RecordVisit { Note = "first" });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(second.Settlement, Is.EqualTo(CatSettlement.Complete));
            Assert.That(await CountAsync<Visit>(), Is.EqualTo(1));
            Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(1));
        }
    }

    [Test]
    public async Task Receive_WhenTheSaveOfTheHandlerFails_LeavesNoInboxRow_SoTheRetryRunsTheHandlerAgain()
    {
        var taken = Guid.NewGuid();
        await ReceiveAsync("message-0", new RecordVisit { VisitId = taken, Note = "already there" });

        // The database refuses the second row with the same key, so the save fails after the inbox row was added.
        var failed = await ReceiveAsync("message-1", new RecordVisit { VisitId = taken, Note = "clash" });
        var inboxAfterTheFailure = await CountAsync<CatInboxMessage>();
        var retried = await ReceiveAsync("message-1", new RecordVisit { Note = "retry" });

        using (Assert.EnterMultipleScope())
        {
            Assert.That(failed.Settlement, Is.EqualTo(CatSettlement.Abandon));
            Assert.That(inboxAfterTheFailure, Is.EqualTo(1), "Only the inbox row of message-0.");
            Assert.That(retried.Settlement, Is.EqualTo(CatSettlement.Complete));
            Assert.That(await CountAsync<Visit>(), Is.EqualTo(2));
            Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(2));
        }
    }

    [Test]
    public async Task Receive_OfTheSameMessageTwiceAtTheSameTime_SavesTheChangeOfTheHandlerOnce()
    {
        // Both deliveries find no inbox row and run the handler. The key of the inbox stops the second save,
        // and its visit is rolled back with it.
        _gate.BeforeSave = new Barrier(2);

        var results = await Task.WhenAll(
            Task.Run(() => ReceiveAsync("message-1", new RecordVisit { Note = "first" })),
            Task.Run(() => ReceiveAsync("message-1", new RecordVisit { Note = "second" })));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(results.Select(r => r.Settlement), Is.EquivalentTo(new[] { CatSettlement.Complete, CatSettlement.Abandon }));
            Assert.That(await CountAsync<Visit>(), Is.EqualTo(1));
            Assert.That(await CountAsync<CatInboxMessage>(), Is.EqualTo(1));
        }
    }
}
