using Cat.Decorators.Abstractions;
using Cat.Decorators.Extensions;
using Cat.Decorators.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Decorators.Tests;

[TestFixture]
public class CatDecoratorFactoryTests
{
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        services.AddTransient<IHandler<string>, Handler<string>>();
        services.AddTransient<IHandler<int>, Handler<int>>();
        services.AddSingleton<IClock, FixedClock>();
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown()
    {
        _provider.Dispose();
    }

    private ICatDecoratorFactory Factory => _provider.GetRequiredService<ICatDecoratorFactory>();

    private ICatDecoratorFactoryBuilder Builder => _provider.GetRequiredService<ICatDecoratorFactoryBuilder>();

    #region Getting a service

    [Test]
    public void GetDecoratedService_WithoutDecorators_ReturnsTheServiceAsItIs()
    {
        var handler = Factory.GetDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler, Is.TypeOf<Handler<string>>());
    }

    [Test]
    public void GetDecoratedService_ServiceIsNotRegistered_ReturnsNull()
    {
        var handler = Factory.GetDecoratedService<IHandler<double>>(_provider);

        Assert.That(handler, Is.Null);
    }

    [Test]
    public void GetDecoratedService_WithTheTypeOverload_Works()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));

        var handler = (IHandler<string>?)Factory.GetDecoratedService(_provider, typeof(IHandler<string>));

        Assert.That(handler!.Handle("a"), Is.EqualTo("HANDLED:A"));
    }

    [Test]
    public void GetRequiredDecoratedService_ServiceIsNotRegistered_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Factory.GetRequiredDecoratedService<IHandler<double>>(_provider));
    }

    [Test]
    public void GetRequiredDecoratedService_WithTheTypeOverload_ThrowsWhenTheServiceIsNotRegistered()
    {
        Assert.Throws<InvalidOperationException>(() => Factory.GetRequiredDecoratedService(_provider, typeof(IHandler<double>)));
    }

    [Test]
    public void GetDecoratedService_ANonGenericServiceType_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => Factory.GetDecoratedService(_provider, typeof(IClock)));
    }

    #endregion Getting a service

    #region Adding decorators

    [Test]
    public void AddDecorator_WrapsTheServiceInTheDecorator()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler, Is.TypeOf<UpperDecorator<string>>());
        Assert.That(handler.Handle("a"), Is.EqualTo("HANDLED:A"));
    }

    [Test]
    public void AddDecorator_AppliesToEveryClosedVersionOfTheService()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>));

        var text = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);
        var number = Factory.GetRequiredDecoratedService<IHandler<int>>(_provider);

        Assert.That(text.Handle("a"), Is.EqualTo("[handled:a]"));
        Assert.That(number.Handle(5), Is.EqualTo("[handled:5]"));
    }

    [Test]
    public void AddDecorator_TheFirstDecoratorIsTheInnermostOne()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        // upper wraps the handler first, the brackets wrap that result
        Assert.That(handler.Handle("a"), Is.EqualTo("[HANDLED:A]"));
        Assert.That(handler, Is.TypeOf<BracketDecorator<string>>());
    }

    [Test]
    public void AddDecorator_TheOrderOfAddingChangesTheResult()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>));
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler.Handle("a"), Is.EqualTo("[HANDLED:A]".ToUpperInvariant()));
        Assert.That(handler, Is.TypeOf<UpperDecorator<string>>());
    }

    [Test]
    public void AddDecorator_ServiceTypeIsNotAnOpenGenericType_Throws()
    {
        Assert.Throws<ArgumentException>(() => Builder.AddDecorator(typeof(IHandler<string>), typeof(UpperDecorator<>)));
    }

    [Test]
    public void AddDecorator_DecoratorTypeIsNotAnOpenGenericType_Throws()
    {
        Assert.Throws<ArgumentException>(() => Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<string>)));
        Assert.Throws<ArgumentException>(() => Builder.AddDecorator(typeof(IHandler<>), typeof(NotGenericHandlerDecorator)));
    }

    [Test]
    public void AddDecorator_ForAnotherService_DoesNotTouchThisOne()
    {
        Builder.AddDecorator(typeof(IEnumerable<>), typeof(List<>));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler, Is.TypeOf<Handler<string>>());
    }

    #endregion Adding decorators

    #region Constructor parameters

    [Test]
    public void Decorator_NeedsAServiceFromTheProvider_GetsItInjected()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(ClockDecorator<>));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler.Handle("a"), Is.EqualTo("12:00 handled:a"));
    }

    [Test]
    public void Decorator_NeedsAServiceThatIsNotRegistered_Throws()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(PrefixDecorator<>));

        Assert.Throws<InvalidOperationException>(() => Factory.GetRequiredDecoratedService<IHandler<string>>(_provider));
    }

    [Test]
    public void Decorator_WithAParameterByName_GetsThatValue()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(PrefixDecorator<>), new CatDecoratorParameter("prefix", ">> "));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler.Handle("a"), Is.EqualTo(">> handled:a"));
    }

    [Test]
    public void Decorator_ParameterWithTheWrongType_IsNotUsed()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(PrefixDecorator<>), new CatDecoratorParameter("prefix", 42));

        Assert.Throws<InvalidOperationException>(() => Factory.GetRequiredDecoratedService<IHandler<string>>(_provider));
    }

    [Test]
    public void Decorator_ParameterWithAnUnknownName_IsIgnored()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), new CatDecoratorParameter("unknown", "x"));

        var handler = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(handler.Handle("a"), Is.EqualTo("HANDLED:A"));
    }

    [Test]
    public void AddDecorator_TwoParametersWithTheSameName_Throws()
    {
        Assert.Throws<ArgumentException>(() => Builder.AddDecorator(
            typeof(IHandler<>),
            typeof(PrefixDecorator<>),
            new CatDecoratorParameter("prefix", "a"),
            new CatDecoratorParameter("prefix", "b")));
    }

    [Test]
    public void Decorator_WithMoreThanOnePublicConstructor_Throws()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(TwoConstructorsDecorator<>));

        Assert.Throws<InvalidOperationException>(() => Factory.GetRequiredDecoratedService<IHandler<string>>(_provider));
    }

    [Test]
    public void Decorator_EachCallWrapsAFreshServiceInstance()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));

        var first = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);
        var second = Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

        Assert.That(second, Is.Not.SameAs(first));
    }

    #endregion Constructor parameters
}
