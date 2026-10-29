using System.Threading;
using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.EventAggregators.Tests.Helpers;

public class VehicleProcessedCounter : IVehicleProcessedCounter, ICatHandleEvent<VehicleProcessedEvent>
{
    public int Counter { get; private set; } = 0;

    public VehicleProcessedCounter(ICatEventAggregator eventAggregator)
    {
        eventAggregator.Subscribe(this);
    }

    public Task HandleEventAsync(VehicleProcessedEvent @event, CancellationToken cancellationToken = default)
    {
        Counter++;
        return Task.CompletedTask;
    }
}