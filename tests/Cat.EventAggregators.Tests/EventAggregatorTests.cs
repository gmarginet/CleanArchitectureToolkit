using System;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;
using Cat.EventAggregators.Extensions;
using Cat.EventAggregators.Tests.Helpers;
using Cat.NUnit;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Cat.EventAggregators.Tests;

public class EventAggregatorTests : UnitTestBase
{
    private ICatEventAggregator EventAggregator { get; set; } = null!;
    
    private IVehicleProcessor VehicleProcessor { get; set; } = null!;
    
    private ICarProcessor CarProcessor { get; set; } = null!;
    
    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatEventAggregatorsModule();
        services.AddSingleton<IVehicleProcessor, VehicleProcessor>();
        services.AddTransient<IVehicleProcessedCounter, VehicleProcessedCounter>();
        services.AddSingleton<ICarProcessor, CarProcessor>();
        services.AddTransient<ICarProcessedCounter, CarProcessedCounter>();
    }

    [OneTimeSetUp]
    protected void OneTimeSetup()
    {
        EventAggregator = ServiceProvider.GetRequiredService<ICatEventAggregator>();
        VehicleProcessor = ServiceProvider.GetRequiredService<IVehicleProcessor>();
        CarProcessor = ServiceProvider.GetRequiredService<ICarProcessor>();
    }
    
    [Test]
    public void EventAggregator_WithoutSubscribers_HasSubscribersForEventShouldBeFalse()
    {
        // arrange
        
        // act
        var hasSubscribersForEvent = EventAggregator.HasSubscribersForEvent(typeof(VehicleProcessedEvent));

        // assert
        Assert.That(hasSubscribersForEvent, Is.False);
    }
    
    [Test]
    public void EventAggregator_WithoutSubscribers_PublishingAnEventShouldNotThrowException()
    {
        // arrange

        // act
        var act = async () =>
        {
            await VehicleProcessor.ProcessAsync();
        };

        // assert
        Assert.DoesNotThrowAsync(() => act());
    }

    [Test]
    public void EventAggregator_Subscribe_HasSubscribersForEventShouldBeTrue()
    {
        // arrange
        var vehicleProcessedCounter = ServiceProvider.GetRequiredService<IVehicleProcessedCounter>();
        vehicleProcessedCounter.ThrowIfNull(nameof(vehicleProcessedCounter));
    
        // act
        var hasSubscribersForEvent = EventAggregator.HasSubscribersForEvent(typeof(VehicleProcessedEvent));

        // assert
        Assert.That(hasSubscribersForEvent, Is.True);
        
        // cleanup
        EventAggregator.Unsubscribe(vehicleProcessedCounter);
    }

    [Test]
    public void EventAggregator_Unsubscribe_HasSubscribersForEventShouldBeFalse()
    {
        // arrange
        var vehicleProcessedCounter = ServiceProvider.GetRequiredService<IVehicleProcessedCounter>();
        vehicleProcessedCounter.ThrowIfNull(nameof(vehicleProcessedCounter));
        if (EventAggregator.HasSubscribersForEvent(typeof(VehicleProcessedEvent)) is false) throw new Exception("No subscriber found for VehicleProcessedEvent");
    
        // act
        EventAggregator.Unsubscribe(vehicleProcessedCounter);
        var hasSubscribersForEvent = EventAggregator.HasSubscribersForEvent(typeof(VehicleProcessedEvent));

        // assert
        Assert.That(hasSubscribersForEvent, Is.False);
    }

    [Test]
    public async Task EventAggregator_PublishingAnEventShouldIncreaseTheCounter()
    {
        // arrange
        var vehicleProcessedCounter = ServiceProvider.GetRequiredService<IVehicleProcessedCounter>();
        vehicleProcessedCounter.ThrowIfNull(nameof(vehicleProcessedCounter));
        if (vehicleProcessedCounter.Counter != 0) throw new Exception("IVehicleProcessedCounter.Counter should be 0");
        
        // act
        await VehicleProcessor.ProcessAsync();
        var count = vehicleProcessedCounter.Counter;

        // assert
        Assert.That(count, Is.EqualTo(1));
        
        // cleanup
        EventAggregator.Unsubscribe(vehicleProcessedCounter);
    }

    [Test]
    public void EventAggregator_PublishingAVehicleEventShouldOnlyIncreaseTheVehicleCounter()
    {
        // arrange
        var vehicleProcessedCounter = ServiceProvider.GetRequiredService<IVehicleProcessedCounter>();
        vehicleProcessedCounter.ThrowIfNull(nameof(vehicleProcessedCounter));
        if (vehicleProcessedCounter.Counter != 0) throw new Exception("IVehicleProcessedCounter.Counter should be 0");

        var carProcessedCounter = ServiceProvider.GetRequiredService<ICarProcessedCounter>();
        carProcessedCounter.ThrowIfNull(nameof(carProcessedCounter));
        if (carProcessedCounter.Counter != 0) throw new Exception("ICarProcessedCounter.Counter should be 0");
        
        var vehicleCount = 0;
        var carCount = 0;

        // act
        var act = async () =>
        {
            await VehicleProcessor.ProcessAsync();
            vehicleCount = vehicleProcessedCounter.Counter;
            carCount = carProcessedCounter.Counter;
        };

        // assert
        Assert.DoesNotThrowAsync(() => act());
        Assert.That(vehicleCount, Is.EqualTo(1));
        Assert.That(carCount, Is.EqualTo(0));
        
        // cleanup
        EventAggregator.Unsubscribe(vehicleProcessedCounter);
        EventAggregator.Unsubscribe(carProcessedCounter);
    }

    [Test]
    public void EventAggregator_PublishingACarEventShouldIncreaseTheCarCounterAndVehicleCounter()
    {
        // arrange
        var vehicleProcessedCounter = ServiceProvider.GetRequiredService<IVehicleProcessedCounter>();
        vehicleProcessedCounter.ThrowIfNull(nameof(vehicleProcessedCounter));
        if (vehicleProcessedCounter.Counter != 0) throw new Exception("IVehicleProcessedCounter.Counter should be 0");

        var carProcessedCounter = ServiceProvider.GetRequiredService<ICarProcessedCounter>();
        carProcessedCounter.ThrowIfNull(nameof(carProcessedCounter));
        if (carProcessedCounter.Counter != 0) throw new Exception("ICarProcessedCounter.Counter should be 0");
         
        var vehicleCount = 0;
        var carCount = 0;
       
        // act
        var act = async () =>
        {
            await CarProcessor.ProcessAsync();
            vehicleCount = vehicleProcessedCounter.Counter;
            carCount = carProcessedCounter.Counter;
        };

        // assert
        Assert.DoesNotThrowAsync(() => act());
        Assert.That(vehicleCount, Is.EqualTo(1));
        Assert.That(carCount, Is.EqualTo(1));
        
        // cleanup
        EventAggregator.Unsubscribe(vehicleProcessedCounter);
        EventAggregator.Unsubscribe(carProcessedCounter);
    }
}