using System.Threading;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.EventAggregators.Tests.Helpers;

public class CarProcessedCounter : ICarProcessedCounter, ICatHandleEvent<CarProcessedEvent>
{
    public int Counter { get; private set; } = 0;
    
    public CarProcessedCounter(ICatEventAggregator eventAggregator)
    {
        eventAggregator.Subscribe(this);
    }

    public Task HandleEventAsync(CarProcessedEvent @event, CancellationToken cancellationToken = default)
    {
        Counter++;
        return Task.CompletedTask;
    }
}