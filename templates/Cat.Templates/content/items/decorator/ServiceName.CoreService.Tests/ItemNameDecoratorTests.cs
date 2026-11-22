#if (ForCommand)
using Cat.Commands.Abstractions;
#endif
#if (ForQuery)
using Cat.Queries.Abstractions;
#endif
#if (ForServiceRequest)
using Cat.ServiceRequests.Abstractions;
#endif
using Cat.UnitTesting.NUnit;
using ServiceName.CoreService.Decorators;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameDecoratorTests
{
    [Test]
    public void Add_ShouldDecorateTheHandlers()
    {
        var builder = new RecordingDecoratorBuilder();

        builder.CreateServiceProvider().AddItemNameDecorator();

#if (ForCommand)
        Assert.That(builder.Added.Select(x => x.ServiceType), Is.EquivalentTo(new[] { typeof(ICatCommandHandler<>), typeof(ICatCommandHandler<,>) }));
#endif
#if (ForQuery)
        Assert.That(builder.Added.Select(x => x.ServiceType), Is.EquivalentTo(new[] { typeof(ICatQueryHandler<,>) }));
#endif
#if (ForServiceRequest)
        Assert.That(builder.Added.Select(x => x.ServiceType), Is.EquivalentTo(new[] { typeof(ICatServiceRequestHandler<>), typeof(ICatServiceRequestHandler<,>) }));
#endif
    }
}
