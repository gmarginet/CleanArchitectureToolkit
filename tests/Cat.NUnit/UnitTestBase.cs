using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Cat.NUnit;

public abstract class UnitTestBase
{
    private ServiceProvider _serviceProvider = null!;
    
    protected IServiceProvider ServiceProvider => _serviceProvider;

    [OneTimeSetUp]
    protected virtual void BaseOneTimeSetup()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    [OneTimeTearDown]
    protected virtual void BaseOneTimeTearDown()
    {
        _serviceProvider?.Dispose();
    }

    protected abstract void ConfigureServices(ServiceCollection services);
}