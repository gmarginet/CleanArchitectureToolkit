using Cat.Decorators.Abstractions;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class UnitTestBaseTests : UnitTestBase
{
    private interface IGreeter
    {
        string Greet();
    }

    private sealed class Greeter : IGreeter
    {
        public string Greet() => "hello";
    }

    private int _configureCalls;

    protected override void ConfigureServices(ServiceCollection services)
    {
        _configureCalls++;
        services.AddSingleton<IGreeter, Greeter>();
    }

    [Test]
    public void ServiceProvider_ShouldHoldTheServicesOfConfigureServices()
    {
        Assert.That(ServiceProvider.GetRequiredService<IGreeter>().Greet(), Is.EqualTo("hello"));
    }

    [Test]
    public void ConfigureServices_ShouldRunOncePerFixture()
    {
        Assert.That(_configureCalls, Is.EqualTo(1));
    }

    [Test]
    public void RecordingDecoratorBuilder_ShouldRecordTheDecoratorsInOrderWithTheirParameters()
    {
        var builder = new RecordingDecoratorBuilder();
        var provider = builder.CreateServiceProvider();

        var recorder = provider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        recorder.AddDecorator(typeof(IGreeter), typeof(Greeter), 250);
        recorder.AddDecorator(typeof(IGreeter), typeof(Greeter));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(recorder, Is.SameAs(builder));
            Assert.That(builder.Added.Select(added => added.Order), Is.EqualTo(new[] { 250, CatDecoratorOrder.Default }));
            Assert.That(builder.Added[0].ServiceType, Is.EqualTo(typeof(IGreeter)));
        }
    }
}
