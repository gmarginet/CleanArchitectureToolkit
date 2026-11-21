using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Cat.Resilience.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Timeout;

namespace Cat.Resilience;

/// <summary>
/// Builds one pipeline per profile for a call that is not HTTP, and keeps it, so the circuit breaker state is shared.
/// </summary>
internal sealed class CatResiliencePipelines(
    CatResilienceProfiles profiles,
    ILoggerFactory? loggerFactory = null,
    TimeProvider? timeProvider = null) : ICatResiliencePipelines
{
    private readonly ConcurrentDictionary<string, ICatResiliencePipeline> _pipelines = new(StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc />
    public ICatResiliencePipeline Get(string profileName) =>
        _pipelines.GetOrAdd(profileName, name => new CatResiliencePipeline(Build(name, profiles.Get(name))));

    private ResiliencePipeline Build(string name, CatResilienceProfileOptions profile)
    {
        var builder = new ResiliencePipelineBuilder
        {
            Name = "cat-" + name,
            InstanceName = name
        };

        if (timeProvider != null)
        {
            builder.TimeProvider = timeProvider;
        }

        builder.AddConcurrencyLimiter(profile.RateLimiter.PermitLimit, profile.RateLimiter.QueueLimit);
        builder.AddTimeout(profile.TotalTimeout.Timeout);

        if (profile.Retry.MaxRetryAttempts > 0)
        {
            builder.AddRetry(new RetryStrategyOptions
            {
                MaxRetryAttempts = profile.Retry.MaxRetryAttempts,
                Delay = profile.Retry.Delay,
                BackoffType = ToPolly(profile.Retry.BackoffType),
                UseJitter = profile.Retry.UseJitter
            });
        }

        builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions
        {
            FailureRatio = profile.CircuitBreaker.FailureRatio,
            MinimumThroughput = profile.CircuitBreaker.MinimumThroughput,
            SamplingDuration = profile.CircuitBreaker.SamplingDuration,
            BreakDuration = profile.CircuitBreaker.BreakDuration
        });
        builder.AddTimeout(profile.AttemptTimeout.Timeout);

        if (loggerFactory != null)
        {
            builder.ConfigureTelemetry(loggerFactory);
        }
        else
        {
            builder.ConfigureTelemetry(NullLoggerFactory.Instance);
        }

        return builder.Build();
    }

    internal static DelayBackoffType ToPolly(CatBackoffType type) => type switch
    {
        CatBackoffType.Constant => DelayBackoffType.Constant,
        CatBackoffType.Linear => DelayBackoffType.Linear,
        _ => DelayBackoffType.Exponential
    };

    private sealed class CatResiliencePipeline(ResiliencePipeline pipeline) : ICatResiliencePipeline
    {
        public Task ExecuteAsync(Func<CancellationToken, Task> callback, CancellationToken cancellationToken = default) =>
            pipeline.ExecuteAsync(ct => new ValueTask(callback(ct)), cancellationToken).AsTask();

        public Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> callback, CancellationToken cancellationToken = default) =>
            pipeline.ExecuteAsync(ct => new ValueTask<TResult>(callback(ct)), cancellationToken).AsTask();
    }
}
