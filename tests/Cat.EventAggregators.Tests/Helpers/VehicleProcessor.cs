using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.EventAggregators.Tests.Helpers;

public class VehicleProcessor : IVehicleProcessor
{
    private readonly ICatEventAggregator _eventAggregator;

    public VehicleProcessor(ICatEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }
    
    public async Task ProcessAsync()
    {
        await _eventAggregator.PublishAsync(new VehicleProcessedEvent());
    }
}