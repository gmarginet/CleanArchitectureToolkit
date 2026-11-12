using Cat.Commands.Decorators.Logging.Extensions;
using Cat.Decorators.Abstractions;
using Cat.NUnit;

namespace Cat.Commands.Tests;

[TestFixture]
public class DecoratorOrderTests
{
    [Test]
    public void Logging_UsesTheLoggingNumberByDefault()
    {
        var builder = new RecordingDecoratorBuilder();

        builder.CreateServiceProvider().AddCatCommandsModuleLoggingDecorator();

        Assert.That(builder.Added, Has.Count.EqualTo(2));
        Assert.That(builder.Added.Select(added => added.Order), Is.All.EqualTo(CatDecoratorOrder.Logging));
    }

    [Test]
    public void Logging_TakesAnOrderThatReplacesTheDefault()
    {
        var builder = new RecordingDecoratorBuilder();

        builder.CreateServiceProvider().AddCatCommandsModuleLoggingDecorator(order: 250);

        Assert.That(builder.Added.Select(added => added.Order), Is.All.EqualTo(250));
    }
}
