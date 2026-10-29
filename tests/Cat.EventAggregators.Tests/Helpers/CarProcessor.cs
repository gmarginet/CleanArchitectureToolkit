using System.Threading.Tasks;
using Cat.EventAggregators.Abstractions;

namespace Cat.EventAggregators.Tests.Helpers;

public class CarProcessor : ICarProcessor
{
    private readonly ICatEventAggregator _eventAggregator;

    public CarProcessor(ICatEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
    }
    
    public async Task ProcessAsync()
    {
        await _eventAggregator.PublishAsync(new CarProcessedEvent());
    }
}