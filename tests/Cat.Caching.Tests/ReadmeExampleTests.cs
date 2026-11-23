using Cat.Caching.Abstractions;
using Cat.Caching.Extensions;
using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Users;
using Cat.Users.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Caching.Tests;

/// <summary>
/// The example of the chapter "Tests" in the module readme. A cached query reaches its handler once, and clearing the tag runs it again.
/// </summary>
[TestFixture]
public class ReadmeExampleTests
{
    [Test]
    public async Task CachedQuery_TheSecondCallSkipsTheHandlerAndTheTagClearsTheEntry()
    {
        var probe = new Probe();
        var services = new ServiceCollection();
        services.AddSingleton(probe);
        services.AddScoped<ICatUser>(_ => new FakeUser());
        services.AddCatQueriesModule(typeof(BookListQueryHandler));
        services.AddCatQueryCaching(options => options.Cache<BookListQuery>(rule => rule.Tag("books")));
        using var provider = services.BuildServiceProvider();

        using var scope = provider.CreateScope();
        var processor = scope.ServiceProvider.GetRequiredService<ICatQueryProcessor>();

        await processor.ProcessAsync(new BookListQuery());
        await processor.ProcessAsync(new BookListQuery());
        Assert.That(probe.Calls, Is.EqualTo(1));

        await provider.GetRequiredService<ICatQueryCache>().RemoveByTagAsync("books");
        await processor.ProcessAsync(new BookListQuery());
        Assert.That(probe.Calls, Is.EqualTo(2));
    }

    public sealed record BookListQuery : ICatQuery<string>;

    public sealed class BookListQueryHandler(Probe probe) : ICatQueryHandler<BookListQuery, string>
    {
        public Task<ICatResponse<string>> HandleAsync(BookListQuery query, CancellationToken cancellationToken = default)
            => Task.FromResult(CatResponse.Ok($"v{probe.Next()}"));
    }
}
