using Cat.Commands.Abstractions;
using Cat.Commands.Extensions;
using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.Resilience.Abstractions;
using Cat.Resilience.Commands;
using Cat.Resilience.Commands.Extensions;
using Cat.Resilience.Extensions;
using Cat.Resilience.Queries;
using Cat.Resilience.Queries.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Resilience.Tests;

[TestFixture]
public class ProcessorRetryTests
{
    private const int MaxRetries = 2;

    private Probe _probe = null!;

    [SetUp]
    public void SetUp() => _probe = new Probe();

    private ServiceProvider Build(Action<CatCommandRetryOptions>? commands = null, Action<CatQueryRetryOptions>? queries = null)
    {
        var services = new ServiceCollection();
        services.AddCatResilienceModule(options =>
        {
            foreach (var profile in options.Profiles.Values)
            {
                profile.Retry.Delay = TimeSpan.Zero;
                profile.Retry.UseJitter = false;
                profile.Retry.BackoffType = CatBackoffType.Constant;
                profile.Retry.MaxRetryAttempts = MaxRetries;
            }
        });
        services.AddSingleton(_probe);
        services.AddScoped<ScopeMarker>();
        services.AddCatCommandsModule(typeof(Probe));
        services.AddCatQueriesModule(typeof(Probe));
        if (commands != null)
        {
            services.AddCatCommandRetry(commands);
        }

        if (queries != null)
        {
            services.AddCatQueryRetry(queries);
        }

        return services.BuildServiceProvider();
    }

    private static ICatResponse ServerError() => CatResponse.InternalServerError(CatError.Create("TST-500", "Boom"));

    private static ICatResponse<int> ServerErrorOfInt() => CatResponse.InternalServerError<int>(CatError.Create("TST-500", "Boom"));

    #region Commands

    [Test]
    public async Task Command_InternalServerError_IsRetriedUntilItSucceeds()
    {
        _probe.Respond = attempt => attempt < 3 ? ServerError() : CatResponse.Ok();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(3));
    }

    [Test]
    public async Task Command_EveryTryRunsInAFreshScope()
    {
        _probe.Respond = attempt => attempt < 3 ? ServerError() : CatResponse.Ok();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(_probe.Scopes, Has.Count.EqualTo(3));
        Assert.That(_probe.Scopes.Distinct().Count(), Is.EqualTo(3));
    }

    [Test]
    public async Task Command_ARetriesRunOutOfTries_ReturnsTheLastResponse()
    {
        _probe.Respond = _ => ServerError();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(response.IsFailed, Is.True);
        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.InternalServerError>());
        Assert.That(_probe.Calls, Is.EqualTo(1 + MaxRetries));
    }

    [Test]
    public async Task Command_BadRequest_IsNeverRetried()
    {
        _probe.Respond = _ => CatResponse.BadRequest(CatError.Create("TST-001", "No"));
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(response.Type, Is.InstanceOf<CatResponseType.Failed.BadRequest>());
        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Command_ATypeThatIsNotListed_IsCalledOnce()
    {
        _probe.Respond = _ => ServerError();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new UnlistedCommand());

        Assert.That(response.IsFailed, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Command_RetryOn_AddsAFailedResponseTypeToTheTable()
    {
        _probe.Respond = attempt => attempt < 2 ? CatResponse.Conflict(CatError.Create("TST-409", "Busy")) : CatResponse.Ok();
        using var provider = Build(commands: options => options.Retry<ListedCommand>(configure: rule => rule.RetryOn<CatResponseType.Failed.Conflict>()));

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task Command_NeverRetryOn_TakesAFailedResponseTypeOutOfTheTable()
    {
        _probe.Respond = _ => ServerError();
        using var provider = Build(commands: options => options.Retry<ListedCommand>(
            configure: rule => rule.NeverRetryOn<CatResponseType.Failed.InternalServerError>()));

        await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Command_AnException_IsRetried()
    {
        _probe.Respond = attempt => attempt < 2 ? throw new InvalidOperationException("glitch") : CatResponse.Ok();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public async Task Command_WithAResult_IsRetried()
    {
        _probe.RespondInt = attempt => attempt < 3 ? ServerErrorOfInt() : CatResponse.Ok(42);
        using var provider = Build(commands: options => options.Retry<ListedResultCommand>());

        var response = await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedResultCommand());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo(42));
        Assert.That(_probe.Calls, Is.EqualTo(3));
    }

    [Test]
    public void Command_Process_RunsTheRetryToo()
    {
        _probe.Respond = attempt => attempt < 2 ? ServerError() : CatResponse.Ok();
        using var provider = Build(commands: options => options.Retry<ListedCommand>());

        var response = provider.GetRequiredService<ICatCommandProcessor>().Process(new ListedCommand());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public void Command_ThePipelineOfAnUnknownProfile_Throws()
    {
        _probe.Respond = _ => ServerError();
        using var provider = Build(commands: options => options.Retry<ListedCommand>("NoSuchProfile"));

        Assert.That(async () => await provider.GetRequiredService<ICatCommandProcessor>().ProcessAsync(new ListedCommand()),
            Throws.Exception);
    }

    [Test]
    public void Command_ACurrentScopeProcessorIsNotWrapped()
    {
        using var provider = Build(commands: options => options.Retry<ListedCommand>());
        using var scope = provider.CreateScope();

        Assert.That(scope.ServiceProvider.GetRequiredService<ICatCurrentScopeCommandProcessor>().GetType().Name, Is.EqualTo("CatCommandProcessor"));
    }

    [Test]
    public void AddCatCommandRetry_AListedTypeAndNoProcessor_Throws()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<InvalidOperationException>(() => services.AddCatCommandRetry(options => options.Retry<ListedCommand>()));

        Assert.That(exception!.Message, Does.Contain("AddCatCommandsModule"));
    }

    [Test]
    public void AddCatCommandRetry_NothingListedAndNoProcessor_DoesNothing()
    {
        var services = new ServiceCollection();

        Assert.That(() => services.AddCatCommandRetry(_ => { }), Throws.Nothing);
    }

    [Test]
    public void Retry_ATypeThatIsNotACommand_Throws()
    {
        var options = new CatCommandRetryOptions();

        Assert.That(() => options.Retry<string>(), Throws.ArgumentException);
    }

    #endregion

    #region Queries

    [Test]
    public async Task Query_InternalServerError_IsRetriedUntilItSucceeds()
    {
        _probe.RespondInt = attempt => attempt < 3 ? ServerErrorOfInt() : CatResponse.Ok(7);
        using var provider = Build(queries: options => options.Retry<ListedQuery>());

        var response = await provider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new ListedQuery());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(response.Value, Is.EqualTo(7));
        Assert.That(_probe.Calls, Is.EqualTo(3));
        Assert.That(_probe.Scopes.Distinct().Count(), Is.EqualTo(3));
    }

    [Test]
    public async Task Query_ATypeThatIsNotListed_IsCalledOnce()
    {
        _probe.RespondInt = _ => ServerErrorOfInt();
        using var provider = Build(queries: options => options.Retry<ListedQuery>());

        var response = await provider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new UnlistedQuery());

        Assert.That(response.IsFailed, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public async Task Query_ARetriesRunOutOfTries_ReturnsTheLastResponse()
    {
        _probe.RespondInt = _ => ServerErrorOfInt();
        using var provider = Build(queries: options => options.Retry<ListedQuery>());

        var response = await provider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new ListedQuery());

        Assert.That(response.IsFailed, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(1 + MaxRetries));
    }

    [Test]
    public async Task Query_NotFound_IsNeverRetried()
    {
        _probe.RespondInt = _ => CatResponse.NotFound<int>(CatError.Create("TST-404", "Gone"));
        using var provider = Build(queries: options => options.Retry<ListedQuery>());

        await provider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new ListedQuery());

        Assert.That(_probe.Calls, Is.EqualTo(1));
    }

    [Test]
    public void Query_Process_RunsTheRetryToo()
    {
        _probe.RespondInt = attempt => attempt < 2 ? ServerErrorOfInt() : CatResponse.Ok(1);
        using var provider = Build(queries: options => options.Retry<ListedQuery>());

        var response = provider.GetRequiredService<ICatQueryProcessor>().Process(new ListedQuery());

        Assert.That(response.IsSucceeded, Is.True);
        Assert.That(_probe.Calls, Is.EqualTo(2));
    }

    [Test]
    public void AddCatQueryRetry_AListedTypeAndNoProcessor_Throws()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<InvalidOperationException>(() => services.AddCatQueryRetry(options => options.Retry<ListedQuery>()));

        Assert.That(exception!.Message, Does.Contain("AddCatQueriesModule"));
    }

    [Test]
    public void Retry_ATypeThatIsNotAQuery_Throws()
    {
        var options = new CatQueryRetryOptions();

        Assert.That(() => options.Retry<string>(), Throws.ArgumentException);
    }

    #endregion

    public sealed class Probe
    {
        private int _calls;

        public int Calls => _calls;

        public List<Guid> Scopes { get; } = [];

        public Func<int, ICatResponse> Respond { get; set; } = _ => CatResponse.Ok();

        public Func<int, ICatResponse<int>> RespondInt { get; set; } = _ => CatResponse.Ok(0);

        public int Next(Guid scope)
        {
            lock (Scopes)
            {
                Scopes.Add(scope);
            }

            return Interlocked.Increment(ref _calls);
        }
    }

    public sealed class ScopeMarker
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    public sealed record ListedCommand : ICatCommand;

    public sealed record UnlistedCommand : ICatCommand;

    public sealed record ListedResultCommand : ICatCommand<int>;

    public sealed record ListedQuery : ICatQuery<int>;

    public sealed record UnlistedQuery : ICatQuery<int>;

    public sealed class ListedCommandHandler(Probe probe, ScopeMarker marker) : ICatCommandHandler<ListedCommand>
    {
        public Task<ICatResponse> HandleAsync(ListedCommand command, CancellationToken cancellationToken = default)
            => Task.FromResult(probe.Respond(probe.Next(marker.Id)));
    }

    public sealed class UnlistedCommandHandler(Probe probe, ScopeMarker marker) : ICatCommandHandler<UnlistedCommand>
    {
        public Task<ICatResponse> HandleAsync(UnlistedCommand command, CancellationToken cancellationToken = default)
            => Task.FromResult(probe.Respond(probe.Next(marker.Id)));
    }

    public sealed class ListedResultCommandHandler(Probe probe, ScopeMarker marker) : ICatCommandHandler<ListedResultCommand, int>
    {
        public Task<ICatResponse<int>> HandleAsync(ListedResultCommand command, CancellationToken cancellationToken = default)
            => Task.FromResult(probe.RespondInt(probe.Next(marker.Id)));
    }

    public sealed class ListedQueryHandler(Probe probe, ScopeMarker marker) : ICatQueryHandler<ListedQuery, int>
    {
        public Task<ICatResponse<int>> HandleAsync(ListedQuery query, CancellationToken cancellationToken = default)
            => Task.FromResult(probe.RespondInt(probe.Next(marker.Id)));
    }

    public sealed class UnlistedQueryHandler(Probe probe, ScopeMarker marker) : ICatQueryHandler<UnlistedQuery, int>
    {
        public Task<ICatResponse<int>> HandleAsync(UnlistedQuery query, CancellationToken cancellationToken = default)
            => Task.FromResult(probe.RespondInt(probe.Next(marker.Id)));
    }
}
