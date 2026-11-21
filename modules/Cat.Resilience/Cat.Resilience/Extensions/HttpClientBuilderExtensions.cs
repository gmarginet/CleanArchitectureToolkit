using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cat.Resilience.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;
using Polly.Retry;

namespace Cat.Resilience.Extensions;

/// <summary>
/// Puts a resilience profile on an <see cref="IHttpClientBuilder"/>.
/// </summary>
public static class HttpClientBuilderExtensions
{
    private const int TooManyRequests = 429;

    /// <summary>
    /// Puts the resilience profile on the client. The pipeline replaces any resilience handler that the client already has,
    /// such as the one a <c>ConfigureHttpClientDefaults</c> call added, so a client never has two retry layers.
    /// The profile has a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try.
    /// The circuit breaker state is kept per client and per process.
    /// A name that no profile has fails the startup of the host.
    /// </summary>
    /// <param name="builder">The client builder.</param>
    /// <param name="profileName">The name of the profile. The default is <see cref="CatResilienceProfile.Internal"/>.</param>
    /// <returns>The same client builder, for chaining.</returns>
    public static IHttpClientBuilder AddCatResilience(this IHttpClientBuilder builder,
        string profileName = CatResilienceProfile.Internal)
    {
        if (string.IsNullOrWhiteSpace(profileName))
        {
            throw new ArgumentException("The profile name is required.", nameof(profileName));
        }

        builder.Services.AddCatResilienceModule();
        builder.Services.AddSingleton(new CatResilienceUse(profileName));

#pragma warning disable EXTEXP0001 // RemoveAllResilienceHandlers is experimental. We need it so the profile replaces the default pipeline.
        builder.RemoveAllResilienceHandlers();
#pragma warning restore EXTEXP0001

        builder.AddResilienceHandler("cat-" + profileName, (pipeline, context) =>
        {
            var profile = context.ServiceProvider.GetRequiredService<CatResilienceProfiles>().Get(profileName);
            Build(pipeline, profile, context.ServiceProvider.GetService<TimeProvider>());
        });

        return builder;
    }

    private static void Build(ResiliencePipelineBuilder<HttpResponseMessage> pipeline,
        CatResilienceProfileOptions profile, TimeProvider? timeProvider)
    {
        if (timeProvider != null)
        {
            pipeline.TimeProvider = timeProvider;
        }

        pipeline.AddConcurrencyLimiter(profile.RateLimiter.PermitLimit, profile.RateLimiter.QueueLimit);
        pipeline.AddTimeout(new HttpTimeoutStrategyOptions { Timeout = profile.TotalTimeout.Timeout });

        if (profile.Retry.MaxRetryAttempts > 0)
        {
            var retry = profile.Retry;
            pipeline.AddRetry(new HttpRetryStrategyOptions
            {
                MaxRetryAttempts = retry.MaxRetryAttempts,
                Delay = retry.Delay,
                BackoffType = CatResiliencePipelines.ToPolly(retry.BackoffType),
                UseJitter = retry.UseJitter,
                ShouldRetryAfterHeader = retry.UseRetryAfterHeader,
                ShouldHandle = args => new ValueTask<bool>(ShouldRetry(args, retry))
            });
        }

        pipeline.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
        {
            FailureRatio = profile.CircuitBreaker.FailureRatio,
            MinimumThroughput = profile.CircuitBreaker.MinimumThroughput,
            SamplingDuration = profile.CircuitBreaker.SamplingDuration,
            BreakDuration = profile.CircuitBreaker.BreakDuration
        });
        pipeline.AddTimeout(new HttpTimeoutStrategyOptions { Timeout = profile.AttemptTimeout.Timeout });
    }

    private static bool ShouldRetry(RetryPredicateArguments<HttpResponseMessage> args, CatRetryOptions retry)
    {
        var outcome = args.Outcome;
        var failed = HttpClientResiliencePredicates.IsTransient(outcome)
                     || (int?)outcome.Result?.StatusCode == TooManyRequests;
        if (!failed)
        {
            return false;
        }

        if (!retry.RequireIdempotencyKeyForUnsafeMethods)
        {
            return true;
        }

        var request = args.Context.GetRequestMessage() ?? outcome.Result?.RequestMessage;
        if (request == null)
        {
            return true;
        }

        return IsSafe(request.Method) || request.Headers.Contains(retry.IdempotencyHeaderName);
    }

    private static bool IsSafe(HttpMethod method) =>
        method == HttpMethod.Get || method == HttpMethod.Head || method == HttpMethod.Options || method == HttpMethod.Trace;
}
