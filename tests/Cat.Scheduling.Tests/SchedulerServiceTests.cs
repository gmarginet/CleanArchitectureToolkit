using Cat.Responses;
using Cat.Scheduling.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class SchedulerServiceTests
{
    private ProcessorState _state = null!;
    private FakeTimeProvider _clock = null!;
    private InMemoryJobClaimStore _store = null!;

    [SetUp]
    public void SetUp()
    {
        _state = new ProcessorState();
        _clock = TestHost.NewClock();
        _store = new InMemoryJobClaimStore();
    }

    [Test]
    public async Task Job_RunsAtEveryDueTime()
    {
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(5), () => _state.Calls >= 3);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.GreaterThanOrEqualTo(3));
        Assert.That(_state.Requests, Is.All.TypeOf<PingRequest>());
    }

    [Test]
    public async Task Job_NothingRunsBeforeTheDueTime()
    {
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromHours(1), () => false, TimeSpan.FromMinutes(5));
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    [Test]
    public async Task Job_DueTimeInItsTimeZone_RunsAtTheRightMoment()
    {
        // Amsterdam is one hour ahead of UTC in November, so 11:30 there is 10:30 UTC. The clock starts at 10:00 UTC.
        using var provider = TestHost.Build(_state, _clock,
            builder => builder.Job<PingRequest>("ping", "30 11 * * *", options => options.TimeZoneId = "Europe/Amsterdam"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromHours(1), () => _state.Calls >= 1, TimeSpan.FromMinutes(1));
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(1));
        Assert.That(_clock.GetUtcNow(), Is.GreaterThanOrEqualTo(new DateTimeOffset(2026, 11, 13, 10, 30, 0, TimeSpan.Zero)));
    }

    [Test]
    public async Task Job_Disabled_NeverRuns()
    {
        var configuration = TestHost.Configuration(("CatScheduling:Jobs:ping:Enabled", "false"));
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), configuration, _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(3), () => _state.Calls > 0);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    [Test]
    public async Task Job_Disabled_CanStillBeRunByTheRunner()
    {
        var configuration = TestHost.Configuration(("CatScheduling:Jobs:ping:Enabled", "false"));
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), configuration, _store);

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("ping");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
    }

    [Test]
    public async Task TwoInstances_OnlyOneRunsTheJob()
    {
        var other = new ProcessorState();
        using var first = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), store: _store);
        using var second = TestHost.Build(other, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), store: _store);
        var schedulerOne = TestHost.Scheduler(first);
        var schedulerTwo = TestHost.Scheduler(second);
        await schedulerOne.StartAsync(CancellationToken.None);
        await schedulerTwo.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromSeconds(90), () => _state.Calls + other.Calls >= 1);
        await Task.Delay(100);
        await schedulerOne.StopAsync(CancellationToken.None);
        await schedulerTwo.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls + other.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Overlap_PreviousRunStillBusy_SkipsTheNewRun()
    {
        var gate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        _state.Respond = async (_, _) =>
        {
            await gate.Task;
            return CatResponse.Ok();
        };
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(1), () => _state.Calls >= 1);
        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(3), () => false, TimeSpan.FromSeconds(5));
        var callsWhileBusy = _state.Calls;
        gate.SetResult(true);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(callsWhileBusy, Is.EqualTo(1));
    }

    [Test]
    public async Task Overlap_Allowed_RunsAgainWhileBusy()
    {
        var gate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        _state.Respond = async (_, _) =>
        {
            await gate.Task;
            return CatResponse.Ok();
        };
        using var provider = TestHost.Build(_state, _clock,
            builder => builder.Job<PingRequest>("ping", "* * * * *", options => options.AllowOverlap = true), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(5), () => _state.Calls >= 2);
        var callsWhileBusy = _state.Calls;
        gate.SetResult(true);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(callsWhileBusy, Is.GreaterThanOrEqualTo(2));
    }

    [Test]
    public async Task MissedRun_RunOnce_RunsOnceForTheLatestMissedDueTime()
    {
        // The job last ran on the 10th. Its due times of the 11th, 12th and 13th (00:05) were missed. It runs once.
        await SeedLastRunAsync("ping", new DateTimeOffset(2026, 11, 10, 0, 5, 0, TimeSpan.Zero));
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);

        await scheduler.StartAsync(CancellationToken.None);
        await TestHost.WaitUntilAsync(() => _state.Calls >= 1);
        await Task.Delay(100);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(1));
        Assert.That(await _store.GetLastDueTimeAsync("ping"), Is.EqualTo(new DateTimeOffset(2026, 11, 13, 0, 5, 0, TimeSpan.Zero)));
    }

    [Test]
    public async Task MissedRun_Skip_DoesNotRun()
    {
        await SeedLastRunAsync("ping", new DateTimeOffset(2026, 11, 10, 0, 5, 0, TimeSpan.Zero));
        using var provider = TestHost.Build(_state, _clock,
            builder => builder.Job<PingRequest>("ping", "5 0 * * *", options => options.MissedRuns = CatMissedRunBehavior.Skip), store: _store);
        var scheduler = TestHost.Scheduler(provider);

        await scheduler.StartAsync(CancellationToken.None);
        await Task.Delay(300);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    [Test]
    public async Task MissedRun_JobNeverRan_DoesNotRunAtStartup()
    {
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);

        await scheduler.StartAsync(CancellationToken.None);
        await Task.Delay(300);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    [Test]
    public async Task MissedRun_LastRunWasTheLatestDueTime_DoesNotRunAgain()
    {
        await SeedLastRunAsync("ping", new DateTimeOffset(2026, 11, 13, 0, 5, 0, TimeSpan.Zero));
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);

        await scheduler.StartAsync(CancellationToken.None);
        await Task.Delay(300);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    [Test]
    public async Task FailedRun_DoesNotStopTheLoop()
    {
        _state.Respond = (attempt, _) => Task.FromResult(attempt == 1 ? CatResponse.BadRequest(CatError.Create("TST-001", "No")) : CatResponse.Ok());
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "* * * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await TestHost.AdvanceUntilAsync(_clock, TimeSpan.FromMinutes(5), () => _state.Calls >= 2);
        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.GreaterThanOrEqualTo(2));
    }

    [Test]
    public async Task Stop_WhileWaiting_StopsWithoutRunning()
    {
        using var provider = TestHost.Build(_state, _clock, builder => builder.Job<PingRequest>("ping", "5 0 * * *"), store: _store);
        var scheduler = TestHost.Scheduler(provider);
        await scheduler.StartAsync(CancellationToken.None);

        await scheduler.StopAsync(CancellationToken.None);

        Assert.That(_state.Calls, Is.EqualTo(0));
    }

    private async Task SeedLastRunAsync(string job, DateTimeOffset due)
    {
        var claim = await _store.TryClaimAsync(job, due, due, true, TimeSpan.FromHours(1));
        await _store.CompleteAsync(claim.Claim!, new CatJobRunResult(CatJobRunStatus.Succeeded, null, 1), due.AddSeconds(1));
    }
}
