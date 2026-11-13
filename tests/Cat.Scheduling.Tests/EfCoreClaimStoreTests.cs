using Cat.Scheduling.Abstractions;
using Cat.Scheduling.EFCore;
using Cat.Scheduling.EFCore.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class EfCoreClaimStoreTests
{
    private static readonly DateTimeOffset Due = new DateTimeOffset(2026, 11, 13, 0, 5, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Now = Due.AddSeconds(1);

    private SqliteConnection _connection = null!;
    private ServiceProvider _provider = null!;
    private ICatJobClaimStore _store = null!;
    private readonly List<ServiceProvider> _extraProviders = new List<ServiceProvider>();

    [SetUp]
    public void SetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddDbContext<SchedulingDbContext>(options => options.UseSqlite(_connection));
        services.AddCatSchedulingEFCore<SchedulingDbContext>();
        _provider = services.BuildServiceProvider();

        using (var scope = _provider.CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<SchedulingDbContext>().Database.EnsureCreated();
        }

        _store = _provider.GetRequiredService<ICatJobClaimStore>();
    }

    [TearDown]
    public void TearDown()
    {
        foreach (var provider in _extraProviders)
        {
            provider.Dispose();
        }

        _extraProviders.Clear();
        _provider.Dispose();
        _connection.Dispose();
    }

    [Test]
    public async Task TryClaim_FirstCaller_ClaimsAndStoresARunningRow()
    {
        var result = await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(result.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
        var row = await ReadRowAsync("job", Due);
        Assert.That(row.Status, Is.EqualTo(CatJobRunStatus.Running));
        Assert.That(row.StartedAt, Is.EqualTo(Now.UtcDateTime));
        Assert.That(row.FinishedAt, Is.Null);
    }

    [Test]
    public async Task TryClaim_SameDueTime_IsTakenByTheFirst()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var second = await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(second.Status, Is.EqualTo(CatJobClaimStatus.TakenByOther));
    }

    [Test]
    public async Task TryClaim_AnotherJob_IsIndependent()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var other = await _store.TryClaimAsync("other", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(other.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task TryClaim_PreviousRunStillBusy_IsBusy()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddDays(1), Now.AddMinutes(30), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Busy));
    }

    [Test]
    public async Task TryClaim_PreviousRunStillBusyAndOverlapAllowed_Claims()
    {
        await _store.TryClaimAsync("job", Due, Now, true, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddMinutes(1), Now.AddMinutes(1), true, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task TryClaim_PreviousRunIsDead_Claims()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddDays(1), Now.AddDays(1), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task Complete_StoresTheOutcome()
    {
        var claim = (await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1))).Claim!;

        await _store.CompleteAsync(claim, new CatJobRunResult(CatJobRunStatus.Failed, "TST-001", 3), Now.AddSeconds(42));

        var row = await ReadRowAsync("job", Due);
        Assert.That(row.Status, Is.EqualTo(CatJobRunStatus.Failed));
        Assert.That(row.ErrorCode, Is.EqualTo("TST-001"));
        Assert.That(row.Attempts, Is.EqualTo(3));
        Assert.That(row.FinishedAt, Is.EqualTo(Now.AddSeconds(42).UtcDateTime));
    }

    [Test]
    public async Task TryClaim_PreviousRunFinished_Claims()
    {
        var first = (await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1))).Claim!;
        await _store.CompleteAsync(first, new CatJobRunResult(CatJobRunStatus.Succeeded, null, 1), Now.AddSeconds(5));

        var next = await _store.TryClaimAsync("job", Due.AddMinutes(1), Now.AddMinutes(1), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task GetLastDueTime_NeverRan_IsNull()
    {
        Assert.That(await _store.GetLastDueTimeAsync("job"), Is.Null);
    }

    [Test]
    public async Task GetLastDueTime_ReturnsTheLatestDueTimeOfThatJobInUtc()
    {
        await _store.TryClaimAsync("job", Due, Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("job", Due.AddDays(2), Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("job", Due.AddDays(1), Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("other", Due.AddDays(9), Now, true, TimeSpan.FromHours(1));

        var last = await _store.GetLastDueTimeAsync("job");

        Assert.That(last, Is.EqualTo(Due.AddDays(2)));
        Assert.That(last!.Value.Offset, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void ModelBuilder_MapsTheTableWithTheJobNameAndDueTimeAsKey()
    {
        using var scope = _provider.CreateScope();
        var entity = scope.ServiceProvider.GetRequiredService<SchedulingDbContext>().Model.FindEntityType(typeof(CatJobRun))!;

        Assert.That(entity.GetTableName(), Is.EqualTo("CatJobRun"));
        Assert.That(entity.FindPrimaryKey()!.Properties.Select(property => property.Name), Is.EqualTo(new[] { "JobName", "DueTime" }));
    }

    [Test]
    public void AddCatSchedulingEFCore_ReplacesTheStoreInMemory()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<ICatJobClaimStore, InMemoryJobClaimStore>();
        services.AddDbContext<SchedulingDbContext>(options => options.UseSqlite(_connection));

        services.AddCatSchedulingEFCore<SchedulingDbContext>();

        using var provider = services.BuildServiceProvider();
        Assert.That(provider.GetRequiredService<ICatJobClaimStore>(), Is.TypeOf<EfCoreJobClaimStore<SchedulingDbContext>>());
    }

    [Test]
    public async Task TryClaim_AnotherInstanceInsertsBetweenTheCheckAndTheInsert_IsTakenByOther()
    {
        // The other instance wins the race: its row lands after our check and before our insert.
        var store = BuildStoreWithInterceptor(new BeforeSaveInterceptor(() => InsertRowAsync("job", Due)));

        var result = await store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(result.Status, Is.EqualTo(CatJobClaimStatus.TakenByOther));
        Assert.That((await ReadRowAsync("job", Due)).StartedAt, Is.EqualTo(Now.AddMinutes(-5).UtcDateTime), "The row of the other instance stays.");
    }

    [Test]
    public void TryClaim_TheInsertFailsForAnotherReason_TheErrorIsNotHidden()
    {
        var store = BuildStoreWithInterceptor(new BeforeSaveInterceptor(() => throw new DbUpdateException("The database is down.")));

        Assert.That(() => store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1)),
            Throws.TypeOf<DbUpdateException>().With.Message.EqualTo("The database is down."));
    }

    private ICatJobClaimStore BuildStoreWithInterceptor(BeforeSaveInterceptor interceptor)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddDbContext<SchedulingDbContext>(options => options.UseSqlite(_connection).AddInterceptors(interceptor));
        services.AddCatSchedulingEFCore<SchedulingDbContext>();
        var provider = services.BuildServiceProvider();
        _extraProviders.Add(provider);
        return provider.GetRequiredService<ICatJobClaimStore>();
    }

    private async Task InsertRowAsync(string job, DateTimeOffset due)
    {
        var options = new DbContextOptionsBuilder<SchedulingDbContext>().UseSqlite(_connection).Options;
        await using var context = new SchedulingDbContext(options);
        context.Set<CatJobRun>().Add(new CatJobRun
        {
            JobName = job,
            DueTime = due.UtcDateTime,
            Status = CatJobRunStatus.Running,
            StartedAt = Now.AddMinutes(-5).UtcDateTime,
        });
        await context.SaveChangesAsync();
    }

    private async Task<CatJobRun> ReadRowAsync(string job, DateTimeOffset due)
    {
        using var scope = _provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchedulingDbContext>();
        var utc = due.UtcDateTime;
        return await context.Set<CatJobRun>().AsNoTracking().SingleAsync(row => row.JobName == job && row.DueTime == utc);
    }

    /// <summary>
    /// Runs an action once, right before the first save. It plays the other instance in a race.
    /// </summary>
    private sealed class BeforeSaveInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor
    {
        private readonly Func<Task> _before;
        private bool _done;

        public BeforeSaveInterceptor(Func<Task> before)
        {
            _before = before;
        }

        public override async ValueTask<Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int>> SavingChangesAsync(
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextEventData eventData,
            Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (!_done)
            {
                _done = true;
                await _before();
            }

            return result;
        }
    }

    private sealed class SchedulingDbContext : DbContext
    {
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.AddCatScheduling();
    }
}
