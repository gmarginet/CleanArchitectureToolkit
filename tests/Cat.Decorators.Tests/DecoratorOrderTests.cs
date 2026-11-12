using Cat.Decorators.Abstractions;
using Cat.Decorators.Extensions;
using Cat.Decorators.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.Decorators.Tests;

[TestFixture]
public class DecoratorOrderTests
{
    private ServiceProvider _provider = null!;
    private ListLogger _logger = null!;

    [SetUp]
    public void SetUp()
    {
        _logger = new ListLogger();
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        services.AddTransient<IHandler<string>, Handler<string>>();
        services.AddSingleton<IClock, FixedClock>();
        services.AddSingleton<ILoggerFactory>(new ListLoggerFactory(_logger));
        _provider = services.BuildServiceProvider();
    }

    [TearDown]
    public void TearDown()
    {
        _provider.Dispose();
    }

    private ICatDecoratorFactory Factory => _provider.GetRequiredService<ICatDecoratorFactory>();

    private ICatDecoratorFactoryBuilder Builder => _provider.GetRequiredService<ICatDecoratorFactoryBuilder>();

    private IHandler<string> Handler => Factory.GetRequiredDecoratedService<IHandler<string>>(_provider);

    #region The order of the decorators

    [Test]
    public void Order_ALowerNumberIsTheOuterDecorator()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 100);
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), 200);

        // the brackets are inside, so the upper case decorator changes them too
        Assert.That(Handler.Handle("a"), Is.EqualTo("[HANDLED:A]"));
        Assert.That(Handler, Is.TypeOf<UpperDecorator<string>>());
    }

    [Test]
    public void Order_TheSequenceOfTheCallsDoesNotMatterWithDifferentNumbers()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), 200);
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 100);

        Assert.That(Handler.Handle("a"), Is.EqualTo("[HANDLED:A]"));
        Assert.That(Handler, Is.TypeOf<UpperDecorator<string>>());
    }

    [Test]
    public void Order_EqualNumbersKeepTheSequenceOfTheCalls()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 300);
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), 300);

        // the first one added is the innermost one, as it was before the order existed
        Assert.That(Handler.Handle("a"), Is.EqualTo("[HANDLED:A]"));
        Assert.That(Handler, Is.TypeOf<BracketDecorator<string>>());
    }

    [Test]
    public void Order_WithoutANumber_UsesTheDefaultNumber()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), CatDecoratorOrder.Default);

        // equal numbers, so the first one added is the innermost one
        Assert.That(Handler, Is.TypeOf<BracketDecorator<string>>());
    }

    [Test]
    public void Order_ADecoratorWithoutANumberSitsInsideValidation()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 600);
        Builder.AddDecorator(typeof(IHandler<>), typeof(PrefixDecorator<>), CatDecoratorOrder.Default, new CatDecoratorParameter("prefix", "p:"));
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), CatDecoratorOrder.Validation);

        // validation (the brackets) is the outermost, then the decorator of the developer, then the one with number 600
        Assert.That(Handler.Handle("a"), Is.EqualTo("[p:HANDLED:A]"));
    }

    [Test]
    public void Order_ADecoratorOfTheDeveloperCanSlotBetweenTwoNumbers()
    {
        // added in a scrambled sequence on purpose
        Builder.AddDecorator(typeof(IHandler<>), typeof(PrefixDecorator<>), 250, new CatDecoratorParameter("prefix", ">>"));
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 300);
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), CatDecoratorOrder.Logging);

        // upper is the innermost, the prefix wraps it, and the brackets are the outermost
        Assert.That(Handler.Handle("a"), Is.EqualTo("[>>HANDLED:A]"));
    }

    [Test]
    public void Order_EachServiceTypeKeepsItsOwnList()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 300);
        Builder.AddDecorator(typeof(IOtherHandler<>), typeof(OtherDecorator<>), 100);

        Assert.That(Handler.Handle("a"), Is.EqualTo("HANDLED:A"));
    }

    [Test]
    public void Info_WithoutAnOrder_HasTheDefaultNumber()
    {
        var info = new CatDecoratorInfo(typeof(UpperDecorator<>), null);

        Assert.That(info.Order, Is.EqualTo(CatDecoratorOrder.Default));
    }

    [Test]
    public void Constants_RunFromTheOutsideIn_InStepsOfOneHundred()
    {
        Assert.That(CatDecoratorOrder.Tracing, Is.EqualTo(100));
        Assert.That(CatDecoratorOrder.Logging, Is.EqualTo(200));
        Assert.That(CatDecoratorOrder.Validation, Is.EqualTo(400));
    }

    [Test]
    public void Constants_TheDefaultSitsAfterValidation()
    {
        Assert.That(CatDecoratorOrder.Default, Is.GreaterThan(CatDecoratorOrder.Validation));
    }

    #endregion The order of the decorators

    #region The startup check

    [Test]
    public void Check_ValidDecorators_DoesNotThrowAndDoesNotLog()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 100);
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>), 200);

        Assert.DoesNotThrow(() => _provider.CheckCatDecorators());
        Assert.That(_logger.Entries, Is.Empty);
    }

    [Test]
    public void Check_WithoutAnyDecorator_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => _provider.CheckCatDecorators());
    }

    [Test]
    public void Check_ReturnsTheServiceProviderSoCallsCanBeChained()
    {
        var returned = _provider.CheckCatDecorators();

        Assert.That(returned, Is.SameAs(_provider));
    }

    [Test]
    public void Check_TwoDecoratorsWithTheSameNumber_LogsAWarning()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));
        Builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>));

        _provider.CheckCatDecorators();

        var entry = _logger.Entries.Single();
        Assert.That(entry.Level, Is.EqualTo(LogLevel.Warning));
        Assert.That(entry.Message, Does.Contain("UpperDecorator`1"));
        Assert.That(entry.Message, Does.Contain("BracketDecorator`1"));
        Assert.That(entry.Message, Does.Contain(CatDecoratorOrder.Default.ToString()));
    }

    [Test]
    public void Check_TwoDecoratorsOfDifferentServicesWithTheSameNumber_LogsNothing()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>), 300);
        Builder.AddDecorator(typeof(IOtherHandler<>), typeof(OtherDecorator<>), 300);

        _provider.CheckCatDecorators();

        Assert.That(_logger.Entries, Is.Empty);
    }

    [Test]
    public void Check_WithoutALoggerFactory_SkipsTheWarnings()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddCatDecoratorsModule();
        using var provider = services.BuildServiceProvider();
        var builder = provider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>));
        builder.AddDecorator(typeof(IHandler<>), typeof(BracketDecorator<>));

        Assert.DoesNotThrow(() => provider.CheckCatDecorators());
    }

    [Test]
    public void Check_ADecoratorWithTwoConstructors_Throws()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(TwoConstructorsDecorator<>));

        var exception = Assert.Throws<InvalidOperationException>(() => _provider.CheckCatDecorators());

        Assert.That(exception!.Message, Does.Contain("TwoConstructorsDecorator`1"));
        Assert.That(exception.Message, Does.Contain("exactly one public constructor"));
    }

    [Test]
    public void Check_ADecoratorWithAnotherNumberOfTypeArguments_Throws()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(PairDecorator<,>));

        var exception = Assert.Throws<InvalidOperationException>(() => _provider.CheckCatDecorators());

        Assert.That(exception!.Message, Does.Contain("PairDecorator`2"));
        Assert.That(exception.Message, Does.Contain("number of type arguments"));
    }

    [Test]
    public void Check_ADecoratorThatDoesNotTakeTheServiceItWraps_Throws()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(NoInnerDecorator<>));

        var exception = Assert.Throws<InvalidOperationException>(() => _provider.CheckCatDecorators());

        Assert.That(exception!.Message, Does.Contain("NoInnerDecorator`1"));
        Assert.That(exception.Message, Does.Contain("no constructor parameter for the service"));
    }

    [Test]
    public void Check_ListsEveryProblemInOneMessage()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(TwoConstructorsDecorator<>));
        Builder.AddDecorator(typeof(IHandler<>), typeof(NoInnerDecorator<>));

        var exception = Assert.Throws<InvalidOperationException>(() => _provider.CheckCatDecorators());

        Assert.That(exception!.Message, Does.Contain("TwoConstructorsDecorator`1"));
        Assert.That(exception.Message, Does.Contain("NoInnerDecorator`1"));
    }

    [Test]
    public void Check_ADecoratorWithAGenericConstraint_IsNotRejectedForTheConstraint()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(ConstrainedDecorator<>));

        Assert.DoesNotThrow(() => _provider.CheckCatDecorators());
    }

    [Test]
    public void Check_IsOffUntilItIsCalled()
    {
        Builder.AddDecorator(typeof(IHandler<>), typeof(TwoConstructorsDecorator<>));

        Assert.DoesNotThrow(() => Builder.AddDecorator(typeof(IHandler<>), typeof(UpperDecorator<>)));
        Assert.That(_logger.Entries, Is.Empty);
    }

    #endregion The startup check

    #region Helpers

    public interface IOtherHandler<T>
    {
        string Handle(T input);
    }

    public class OtherDecorator<T> : IOtherHandler<T>
    {
        private readonly IOtherHandler<T> _inner;

        public OtherDecorator(IOtherHandler<T> inner)
        {
            _inner = inner;
        }

        public string Handle(T input) => _inner.Handle(input);
    }

    public class PairDecorator<T1, T2> : IHandler<T1>
    {
        private readonly IHandler<T1> _inner;

        public PairDecorator(IHandler<T1> inner)
        {
            _inner = inner;
        }

        public string Handle(T1 input) => _inner.Handle(input);
    }

    public class NoInnerDecorator<T> : IHandler<T>
    {
        public NoInnerDecorator(IClock clock)
        {
        }

        public string Handle(T input) => "no inner";
    }

    public class ConstrainedDecorator<T> : IHandler<T> where T : struct
    {
        private readonly IHandler<T> _inner;

        public ConstrainedDecorator(IHandler<T> inner)
        {
            _inner = inner;
        }

        public string Handle(T input) => _inner.Handle(input);
    }

    private sealed class ListLogger : ILogger
    {
        public List<(LogLevel Level, string Message)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Entries.Add((logLevel, formatter(state, exception)));
        }
    }

    private sealed class ListLoggerFactory : ILoggerFactory
    {
        private readonly ILogger _logger;

        public ListLoggerFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger CreateLogger(string categoryName) => _logger;

        public void AddProvider(ILoggerProvider provider)
        {
        }

        public void Dispose()
        {
        }
    }

    #endregion Helpers
}
