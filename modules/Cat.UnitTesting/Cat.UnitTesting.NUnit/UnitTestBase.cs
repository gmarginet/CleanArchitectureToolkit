using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Cat.UnitTesting.NUnit;

/// <summary>
/// Base class for a test fixture that needs a service provider. It builds the provider once per fixture
/// from <see cref="ConfigureServices"/> and disposes it after the last test.
/// </summary>
public abstract class UnitTestBase
{
    private ServiceProvider _serviceProvider = null!;

    /// <summary>
    /// The service provider of the fixture. It exists from the one time setup on.
    /// </summary>
    protected IServiceProvider ServiceProvider => _serviceProvider;

    /// <summary>
    /// Builds the service provider. NUnit runs it once before the first test of the fixture.
    /// </summary>
    [OneTimeSetUp]
    protected virtual void BaseOneTimeSetup()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    /// <summary>
    /// Disposes the service provider. NUnit runs it once after the last test of the fixture.
    /// </summary>
    [OneTimeTearDown]
    protected virtual void BaseOneTimeTearDown()
    {
        _serviceProvider?.Dispose();
    }

    /// <summary>
    /// Registers the services of the fixture.
    /// </summary>
    /// <param name="services">The collection to register the services in.</param>
    protected abstract void ConfigureServices(ServiceCollection services);
}