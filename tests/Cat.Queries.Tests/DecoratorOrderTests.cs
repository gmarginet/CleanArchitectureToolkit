using Cat.Decorators.Abstractions;
using Cat.UnitTesting.NUnit;
using Cat.Queries.Decorators.Logging.Extensions;

namespace Cat.Queries.Tests;

[TestFixture]
public class DecoratorOrderTests
{
    [Test]
    public void Logging_UsesTheLoggingNumberByDefault()
    {
        var builder = new RecordingDecoratorBuilder();

        builder.CreateServiceProvider().AddCatQueriesModuleLoggingDecorator();

        Assert.That(builder.Added.Select(added => added.Order), Is.EqualTo(new[] { CatDecoratorOrder.Logging }));
    }

    [Test]
    public void Logging_TakesAnOrderThatReplacesTheDefault()
    {
        var builder = new RecordingDecoratorBuilder();

        builder.CreateServiceProvider().AddCatQueriesModuleLoggingDecorator(order: 250);

        Assert.That(builder.Added.Select(added => added.Order), Is.EqualTo(new[] { 250 }));
    }
}
