using Cat.Scheduling.Abstractions;
using Cat.Scheduling.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class BuilderTests
{
    [Test]
    public void Job_Generic_DeclaresTheJobWithTheCronExpression()
    {
        var builder = new CatSchedulerBuilder().Job<PingRequest>("ping", "5 0 * * *");

        var job = builder.Registrations.Single();
        Assert.That(job.Name, Is.EqualTo("ping"));
        Assert.That(job.Options.Cron, Is.EqualTo("5 0 * * *"));
        Assert.That(job.Options.TimeZoneId, Is.EqualTo("UTC"));
        Assert.That(job.Options.Enabled, Is.True);
        Assert.That(job.Options.MissedRuns, Is.EqualTo(CatMissedRunBehavior.RunOnce));
        Assert.That(job.Options.MaxRetries, Is.EqualTo(0));
    }

    [Test]
    public void Job_Generic_CreatesANewRequestForEveryRun()
    {
        var builder = new CatSchedulerBuilder().Job<PingRequest>("ping", "5 0 * * *");

        var factory = builder.Registrations.Single().RequestFactory;

        var first = factory();
        var second = factory();
        Assert.That(first, Is.Not.SameAs(second));
        Assert.That(first, Is.TypeOf<PingRequest>());
    }

    [Test]
    public void Job_WithFactory_UsesTheFactory()
    {
        var builder = new CatSchedulerBuilder().Job("greet", "5 0 * * *", () => new GreetRequest("Ada"));

        Assert.That(builder.Registrations.Single().RequestFactory(), Is.EqualTo(new GreetRequest("Ada")));
    }

    [Test]
    public void Job_Configure_ChangesTheOptions()
    {
        var builder = new CatSchedulerBuilder().Job<PingRequest>("ping", "5 0 * * *", options =>
        {
            options.TimeZoneId = "Europe/Amsterdam";
            options.AllowOverlap = true;
            options.MaxRetries = 3;
        });

        var options = builder.Registrations.Single().Options;
        Assert.That(options.TimeZoneId, Is.EqualTo("Europe/Amsterdam"));
        Assert.That(options.AllowOverlap, Is.True);
        Assert.That(options.MaxRetries, Is.EqualTo(3));
    }

    [Test]
    public void Job_DuplicateName_Throws()
    {
        var builder = new CatSchedulerBuilder().Job<PingRequest>("ping", "5 0 * * *");

        Assert.Throws<ArgumentException>(() => builder.Job<PingRequest>("PING", "10 0 * * *"));
    }

    [Test]
    public void Job_EmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new CatSchedulerBuilder().Job<PingRequest>(" ", "5 0 * * *"));
    }

    [Test]
    public void RunAs_SetsTheSystemUserName()
    {
        var builder = new CatSchedulerBuilder().RunAs("orders");

        Assert.That(builder.SystemUserName, Is.EqualTo("orders"));
        Assert.That(new CatSchedulerBuilder().SystemUserName, Is.EqualTo(CatSchedulerBuilder.DefaultSystemUserName));
    }

    [Test]
    public void AddCatScheduling_RegistersTheRegistryTheRunnerAndTheHostedService()
    {
        using var provider = TestHost.Build(new ProcessorState(), TestHost.NewClock(), builder => builder.Job<PingRequest>("ping", "5 0 * * *"));

        Assert.That(provider.GetRequiredService<ICatJobRegistry>().Jobs.Select(job => job.Name), Is.EqualTo(new[] { "ping" }));
        Assert.That(provider.GetRequiredService<ICatJobRunner>(), Is.Not.Null);
        Assert.That(TestHost.Scheduler(provider), Is.TypeOf<CatSchedulerService>());
        Assert.That(provider.GetRequiredService<ICatJobClaimStore>(), Is.TypeOf<InMemoryJobClaimStore>());
    }

    [Test]
    public void AddCatScheduling_AClaimStoreRegisteredBefore_IsKept()
    {
        var own = new InMemoryJobClaimStore();

        using var provider = TestHost.Build(new ProcessorState(), TestHost.NewClock(), builder => builder.Job<PingRequest>("ping", "5 0 * * *"),
            store: own);

        Assert.That(provider.GetRequiredService<ICatJobClaimStore>(), Is.SameAs(own));
    }

    [Test]
    public void AddCatScheduling_NotValidCron_ThrowsAtRegistration()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            TestHost.Build(new ProcessorState(), TestHost.NewClock(), builder => builder.Job<PingRequest>("ping", "not a cron")));

        Assert.That(exception!.Message, Does.Contain("ping"));
    }

    [Test]
    public void AddCatScheduling_UnknownTimeZone_ThrowsAtRegistration()
    {
        Assert.Throws<ArgumentException>(() =>
            TestHost.Build(new ProcessorState(), TestHost.NewClock(),
                builder => builder.Job<PingRequest>("ping", "5 0 * * *", options => options.TimeZoneId = "Mars/Olympus")));
    }

    [Test]
    public void AddCatScheduling_Configuration_WinsOverTheCode()
    {
        var configuration = TestHost.Configuration(
            ("CatScheduling:Jobs:ping:Cron", "0 3 * * *"),
            ("CatScheduling:Jobs:ping:Enabled", "false"),
            ("CatScheduling:Jobs:ping:MaxRetries", "2"),
            ("CatScheduling:Jobs:ping:RetryDelay", "00:00:10"),
            ("CatScheduling:Jobs:ping:MissedRuns", "Skip"));

        using var provider = TestHost.Build(new ProcessorState(), TestHost.NewClock(), builder => builder.Job<PingRequest>("ping", "5 0 * * *"), configuration);

        var options = provider.GetRequiredService<ICatJobRegistry>().Jobs.Single().Options;
        Assert.That(options.Cron, Is.EqualTo("0 3 * * *"));
        Assert.That(options.Enabled, Is.False);
        Assert.That(options.MaxRetries, Is.EqualTo(2));
        Assert.That(options.RetryDelay, Is.EqualTo(TimeSpan.FromSeconds(10)));
        Assert.That(options.MissedRuns, Is.EqualTo(CatMissedRunBehavior.Skip));
    }

    [Test]
    public void AddCatScheduling_NotValidCronInConfiguration_ThrowsAtRegistration()
    {
        var configuration = TestHost.Configuration(("CatScheduling:Jobs:ping:Cron", "nonsense"));

        Assert.Throws<ArgumentException>(() =>
            TestHost.Build(new ProcessorState(), TestHost.NewClock(), builder => builder.Job<PingRequest>("ping", "5 0 * * *"), configuration));
    }

    [Test]
    public void CronSchedule_SixFields_IncludesSeconds()
    {
        var schedule = CronSchedule.Create("fast", new CatJobOptions { Cron = "*/30 * * * * *" });

        var next = schedule.GetNext(new DateTimeOffset(2026, 11, 13, 10, 0, 10, TimeSpan.Zero));

        Assert.That(next, Is.EqualTo(new DateTimeOffset(2026, 11, 13, 10, 0, 30, TimeSpan.Zero)));
    }

    [Test]
    public void CronSchedule_TimeZone_ReadsTheExpressionInThatZone()
    {
        // 03:00 in Amsterdam is 02:00 UTC in November, when daylight saving is over.
        var schedule = CronSchedule.Create("nightly",
            new CatJobOptions { Cron = "0 3 * * *", TimeZoneId = "Europe/Amsterdam" });

        var next = schedule.GetNext(new DateTimeOffset(2026, 11, 13, 0, 0, 0, TimeSpan.Zero));

        Assert.That(next!.Value.UtcDateTime, Is.EqualTo(new DateTime(2026, 11, 13, 2, 0, 0, DateTimeKind.Utc)));
    }
}
