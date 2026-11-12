using Cat.Decorators.Abstractions;
using Cat.NUnit;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;
using Cat.ServiceRequests.Extensions;
using Cat.ServiceRequests.Tests.Helpers;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Tests;

[TestFixture]
public class DecoratorOrderTests
{
    private RecordingDecoratorBuilder _builder = null!;
    private IServiceProvider _provider = null!;

    [SetUp]
    public void SetUp()
    {
        _builder = new RecordingDecoratorBuilder();
        _provider = _builder.CreateServiceProvider();
    }

    [Test]
    public void ActivitySource_UsesTheTracingNumberByDefault()
    {
        _provider.AddCatServiceRequestsModuleActivitySourceDecorator();

        Assert.That(_builder.Added, Has.Count.EqualTo(2));
        Assert.That(_builder.Added.Select(added => added.Order), Is.All.EqualTo(CatDecoratorOrder.Tracing));
    }

    [Test]
    public void Logging_UsesTheLoggingNumberByDefault()
    {
        _provider.AddCatServiceRequestsModuleLoggingDecorator();

        Assert.That(_builder.Added, Has.Count.EqualTo(2));
        Assert.That(_builder.Added.Select(added => added.Order), Is.All.EqualTo(CatDecoratorOrder.Logging));
    }

    [Test]
    public void Validation_UsesTheValidationNumberByDefaultAndKeepsItsParameter()
    {
        _provider.AddCatServiceRequestsModuleValidationDecorator(validationRequired: true);

        Assert.That(_builder.Added, Has.Count.EqualTo(2));
        Assert.That(_builder.Added.Select(added => added.Order), Is.All.EqualTo(CatDecoratorOrder.Validation));
        Assert.That(_builder.Added.Select(added => added.Parameters["validationRequired"]), Is.All.EqualTo(true));
    }

    [Test]
    public void EachDecorator_TakesAnOrderThatReplacesTheDefault()
    {
        _provider.AddCatServiceRequestsModuleActivitySourceDecorator(order: 150);
        _provider.AddCatServiceRequestsModuleLoggingDecorator(order: 250);
        _provider.AddCatServiceRequestsModuleValidationDecorator(order: 450);

        Assert.That(_builder.Added.Select(added => added.Order), Is.EqualTo(new[] { 150, 150, 250, 250, 450, 450 }));
    }

    [Test]
    public void Validation_AnOrderDoesNotChangeTheValidationRequiredDefault()
    {
        _provider.AddCatServiceRequestsModuleValidationDecorator(order: 450);

        Assert.That(_builder.Added.Select(added => added.Parameters["validationRequired"]), Is.All.EqualTo(false));
    }

    [Test]
    public void TheDefaultOrder_RunsTracingThenLoggingThenValidationFromTheOutsideIn()
    {
        Assert.That(CatDecoratorOrder.Tracing, Is.LessThan(CatDecoratorOrder.Logging));
        Assert.That(CatDecoratorOrder.Logging, Is.LessThan(CatDecoratorOrder.Validation));
    }

    [TestCase("validation,logging,tracing")]
    [TestCase("tracing,logging,validation")]
    [TestCase("logging,validation,tracing")]
    [TestCase("tracing,validation,logging")]
    public void RealHandler_IsWrappedFromTheOutsideInWhateverTheSequenceOfTheCalls(string sequence)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<RequestRecorder>();
        services.AddScoped<ScopedMarker>();
        services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger<>), typeof(CollectingLogger<>));
        services.AddSingleton<LogCollector>();
        services.AddCatServiceRequestsModule(typeof(CreateOrderRequestHandler));
        services.AddCatValidatorsModule(typeof(CreateOrderRequestHandler));
        using var provider = services.BuildServiceProvider();

        foreach (var name in sequence.Split(','))
        {
            switch (name)
            {
                case "validation": provider.AddCatServiceRequestsModuleValidationDecorator(); break;
                case "logging": provider.AddCatServiceRequestsModuleLoggingDecorator(); break;
                case "tracing": provider.AddCatServiceRequestsModuleActivitySourceDecorator(); break;
            }
        }

        var factory = provider.GetRequiredService<ICatDecoratorFactory>();
        var handler = factory.GetRequiredDecoratedService(provider, typeof(ICatServiceRequestHandler<CreateOrderRequest>));

        // walk from the outermost decorator inward, through the field that holds the wrapped handler
        var chain = new List<string>();
        while (handler.GetType().DeclaringType is { } declaring && declaring.Name.EndsWith("Decorator"))
        {
            chain.Add(declaring.Name);
            handler = handler.GetType()
                .GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .Where(field => typeof(ICatServiceRequestHandler<CreateOrderRequest>).IsAssignableFrom(field.FieldType))
                .Select(field => field.GetValue(handler)!)
                .First();
        }

        Assert.That(chain, Is.EqualTo(new[] { "ActivitySourceDecorator", "LoggingDecorator", "ValidationDecorator" }));
        Assert.That(handler, Is.TypeOf<CreateOrderRequestHandler>());
    }
}
