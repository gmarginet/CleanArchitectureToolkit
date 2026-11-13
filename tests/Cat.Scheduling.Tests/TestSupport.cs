using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Scheduling.Abstractions;
using Cat.Scheduling.Extensions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Users;
using Cat.Users.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Time.Testing;

namespace Cat.Scheduling.Tests;

/// <summary>
/// A service request without data, for the jobs of the tests.
/// </summary>
public record PingRequest : ICatServiceRequest;

/// <summary>
/// A service request with data, for the factory overload.
/// </summary>
public record GreetRequest(string Name) : ICatServiceRequest;

/// <summary>
/// What the fake processor saw. It is shared by every scope, because the real processor is scoped.
/// </summary>
internal sealed class ProcessorState
{
    private readonly object _lock = new object();
    private readonly List<ICatServiceRequest> _requests = new List<ICatServiceRequest>();
    private readonly List<ICatUser> _users = new List<ICatUser>();

    /// <summary>
    /// Decides the response of an attempt. The argument is the number of the attempt, starting at 1.
    /// </summary>
    public Func<int, CancellationToken, Task<ICatResponse>> Respond { get; set; } = (_, _) => Task.FromResult(CatResponse.Ok());

    public int Calls
    {
        get { lock (_lock) { return _requests.Count; } }
    }

    public IReadOnlyList<ICatServiceRequest> Requests
    {
        get { lock (_lock) { return _requests.ToList(); } }
    }

    public IReadOnlyList<ICatUser> Users
    {
        get { lock (_lock) { return _users.ToList(); } }
    }

    public Task<ICatResponse> HandleAsync(ICatServiceRequest request, ICatUser? user, CancellationToken cancellationToken)
    {
        int attempt;
        lock (_lock)
        {
            _requests.Add(request);
            if (user != null)
            {
                _users.Add(user);
            }

            attempt = _requests.Count;
        }

        return Respond(attempt, cancellationToken);
    }
}

internal sealed class FakeProcessor : ICatServiceRequestProcessor
{
    private readonly ProcessorState _state;
    private readonly ICatUserAccessor? _accessor;

    public FakeProcessor(ProcessorState state, ICatUserAccessor? accessor)
    {
        _state = state;
        _accessor = accessor;
    }

    public Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default)
        => _state.HandleAsync(catServiceRequest, _accessor?.User, cancellationToken);

    public Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest,
        CancellationToken cancellationToken = default) => throw new NotSupportedException();

    public ICatResponse Process(ICatServiceRequest catServiceRequest) => throw new NotSupportedException();

    public ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest) => throw new NotSupportedException();
}

internal static class TestHost
{
    public static readonly DateTimeOffset Start = new DateTimeOffset(2026, 11, 13, 10, 0, 0, TimeSpan.Zero);

    public static FakeTimeProvider NewClock() => new FakeTimeProvider(Start);

    public static IConfiguration Configuration(params (string Key, string Value)[] values)
    {
        return new ConfigurationBuilder()
            .AddInMemoryCollection(values.ToDictionary(pair => pair.Key, pair => (string?)pair.Value))
            .Build();
    }

    public static ServiceProvider Build(ProcessorState state, FakeTimeProvider clock, Action<CatSchedulerBuilder> declare,
        IConfiguration? configuration = null, ICatJobClaimStore? store = null, Action<IServiceCollection>? more = null)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddLogging();
        services.AddSingleton<TimeProvider>(clock);
        services.AddScoped<ICatUserAccessor, FakeUserAccessor>();
        services.AddScoped<ICatServiceRequestProcessor>(provider => new FakeProcessor(state, provider.GetService<ICatUserAccessor>()));
        if (store != null)
        {
            services.AddSingleton(store);
        }

        more?.Invoke(services);
        services.AddCatScheduling(configuration ?? Configuration(), declare);
        return services.BuildServiceProvider();
    }

    public static IHostedService Scheduler(ServiceProvider provider) => provider.GetServices<IHostedService>().Single();

    /// <summary>
    /// Moves the fake clock forward in small steps until the condition is true. The loops of the scheduler
    /// start on other threads, and a timer that does not exist yet cannot fire, so the steps are small and
    /// the real wait between them gives the loops time to set their timers.
    /// </summary>
    public static async Task AdvanceUntilAsync(FakeTimeProvider clock, TimeSpan limit, Func<bool> condition, TimeSpan? step = null)
    {
        var size = step ?? TimeSpan.FromSeconds(1);
        for (var spent = TimeSpan.Zero; spent < limit && !condition(); spent += size)
        {
            await Task.Delay(5);
            clock.Advance(size);
        }

        await Task.Delay(30);
    }

    public static async Task<bool> WaitUntilAsync(Func<bool> condition, int milliseconds = 3000)
    {
        for (var waited = 0; waited < milliseconds; waited += 10)
        {
            if (condition())
            {
                return true;
            }

            await Task.Delay(10);
        }

        return condition();
    }
}
