using Microsoft.Extensions.DependencyInjection;

namespace Cat.Extensions.Tests;

[TestFixture]
public class ServiceCollectionExtensionsTests
{
    private interface IService;

    private class Service : IService;

    private interface IRepository<T>;

    private class Repository<T> : IRepository<T>;

    [Test]
    public void HasRegistrationFor_RegisteredService_ReturnsTrue()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IService, Service>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<IService>(services), Is.True);
    }

    [Test]
    public void HasRegistrationFor_ServiceThatIsNotRegistered_ReturnsFalse()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<IService>(services), Is.False);
    }

    [Test]
    public void HasRegistrationFor_OnlyTheImplementationIsRegistered_ReturnsFalseForTheInterface()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<Service>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<IService>(services), Is.False);
        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<Service>(services), Is.True);
    }

    [Test]
    public void HasRegistrationFor_WithAType_Works()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IService, Service>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(services, typeof(IService)), Is.True);
        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(services, typeof(Service)), Is.False);
    }

    [Test]
    public void HasRegistrationFor_OpenGenericType_MatchesAnyClosedRegistration()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IRepository<int>, Repository<int>>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(services, typeof(IRepository<>)), Is.True);
    }

    [Test]
    public void HasRegistrationFor_OpenGenericType_MatchesAnOpenRegistration()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(services, typeof(IRepository<>)), Is.True);
    }

    [Test]
    public void HasRegistrationFor_ClosedGenericType_OnlyMatchesTheSameArguments()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IRepository<int>, Repository<int>>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<IRepository<int>>(services), Is.True);
        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor<IRepository<string>>(services), Is.False);
    }

    [Test]
    public void HasRegistrationFor_OpenGenericTypeWithoutRegistrations_ReturnsFalse()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton<IService, Service>();

        Assert.That(Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(services, typeof(IRepository<>)), Is.False);
    }
}
