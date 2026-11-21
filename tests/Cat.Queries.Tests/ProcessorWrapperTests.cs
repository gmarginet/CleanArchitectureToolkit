using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.Queries.Tests.Helpers;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Queries.Tests;

[TestFixture]
public class ProcessorWrapperTests
{
    private static ServiceCollection CreateServices()
    {
        var services = new ServiceCollection();
        services.AddCatQueriesModule(typeof(GetUserQuery));
        return services;
    }

    [Test]
    public async Task Wrappers_GoInTheOrderOfTheirNumber_WhateverTheOrderOfTheCalls([Values] bool outerFirst)
    {
        var log = new List<string>();
        var services = CreateServices();
        if (outerFirst)
        {
            services.AddCatQueryProcessorWrapper(CatQueryProcessorOrder.Caching, (_, inner) => new RecordingProcessor("outer", inner, log), "Test");
            services.AddCatQueryProcessorWrapper(CatQueryProcessorOrder.Retry, (_, inner) => new RecordingProcessor("inner", inner, log), "Test");
        }
        else
        {
            services.AddCatQueryProcessorWrapper(CatQueryProcessorOrder.Retry, (_, inner) => new RecordingProcessor("inner", inner, log), "Test");
            services.AddCatQueryProcessorWrapper(CatQueryProcessorOrder.Caching, (_, inner) => new RecordingProcessor("outer", inner, log), "Test");
        }

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new WrapperQuery());

        Assert.That(log, Is.EqualTo(new[] { "outer", "inner" }));
    }

    [Test]
    public async Task Wrappers_WithTheSameNumber_TheLastCallIsOutside()
    {
        var log = new List<string>();
        var services = CreateServices();
        services.AddCatQueryProcessorWrapper(150, (_, inner) => new RecordingProcessor("first", inner, log), "Test");
        services.AddCatQueryProcessorWrapper(150, (_, inner) => new RecordingProcessor("last", inner, log), "Test");

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        await scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>().ProcessAsync(new WrapperQuery());

        Assert.That(log, Is.EqualTo(new[] { "last", "first" }));
    }

    [Test]
    public void Wrapper_GetsTheServiceProviderOfTheScope()
    {
        var services = CreateServices();
        IServiceProvider? seen = null;
        services.AddCatQueryProcessorWrapper(100, (provider, inner) =>
        {
            seen = provider;
            return inner;
        }, "Test");

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>();

        Assert.That(seen, Is.SameAs(scope.ServiceProvider));
    }

    [Test]
    public void Wrapper_WithoutAProcessor_ThrowsAndNamesTheCall()
    {
        var services = new ServiceCollection();

        var exception = Assert.Throws<InvalidOperationException>(
            () => services.AddCatQueryProcessorWrapper(100, (_, inner) => inner, "AddSomething"));

        Assert.That(exception!.Message, Does.Contain("AddCatQueriesModule"));
        Assert.That(exception.Message, Does.Contain("AddSomething"));
    }

    private sealed class RecordingProcessor(string name, ICatQueryProcessor inner, List<string> log) : ICatQueryProcessor
    {
        public Task<ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(ICatQuery<TQueryResult> catQuery, CancellationToken cancellationToken = default)
        {
            log.Add(name);
            return inner.ProcessAsync(catQuery, cancellationToken);
        }

        public ICatResponse<TQueryResult> Process<TQueryResult>(ICatQuery<TQueryResult> catQuery)
        {
            log.Add(name);
            return inner.Process(catQuery);
        }
    }
}

public sealed record WrapperQuery : ICatQuery<string>;

public sealed class WrapperQueryHandler : ICatQueryHandler<WrapperQuery, string>
{
    public Task<ICatResponse<string>> HandleAsync(WrapperQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(Cat.Responses.CatResponse.Ok("ok"));
}
